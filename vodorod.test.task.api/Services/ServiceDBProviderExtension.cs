using Serilog;
using vodorod.test.task.data.access;

namespace vodorod.test.task.api.Services
{
    public static class ServiceDBProviderExtension
    {
        public static void AddAutomaticMigrationsEF(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var environment = services.GetRequiredService<IWebHostEnvironment>();

                    if (!environment.IsDevelopment())
                    {
                        var context = services.GetRequiredService<VodorotTestTaskDbContext>();
                        DbInitializer.Initialize(context);
                    }
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "Tables can`t be created!");
                }
            }
        }
    }
}
