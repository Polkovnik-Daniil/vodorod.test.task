using Microsoft.EntityFrameworkCore;
using vodorod.test.task.core.Abstractions;
using vodorod.test.task.application.Services;
using vodorod.test.task.data.access;
using vodorod.test.task.data.access.Repositories;
using Serilog;
using Serilog.Events;
using Microsoft.Extensions.Hosting;
using vodorod.test.task.api.Services;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger(); // <-- Change this line!

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSerilog((services, lc) => lc
                    .ReadFrom.Configuration(builder.Configuration)
                    .ReadFrom.Services(services)
                    .Enrich.FromLogContext()
                    .WriteTo.Console());

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<VodorotTestTaskDbContext>(
        options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(VodorotTestTaskDbContext)));
        });
    builder.Services.AddScoped<IModelsService, RatesService>();
    builder.Services.AddScoped<IEntityClassesRepository, RateEntityRepository>();
    var app = builder.Build();

    ServiceDBProviderExtension.AddAutomaticMigrationsEF(app);

    app.UseSerilogRequestLogging(); // <-- Add this line

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}