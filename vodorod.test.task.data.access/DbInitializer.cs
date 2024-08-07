using Microsoft.EntityFrameworkCore;


namespace vodorod.test.task.data.access
{
    public static class DbInitializer
    { 
        public static void Initialize(VodorotTestTaskDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
