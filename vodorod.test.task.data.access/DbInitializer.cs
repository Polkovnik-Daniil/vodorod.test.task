using Microsoft.EntityFrameworkCore;


namespace vodorod.test.task.data.access
{
    /// <summary>
    /// Инициализирует БД
    /// </summary>
    public static class DbInitializer
    { 
        public static void Initialize(VodorotTestTaskDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
