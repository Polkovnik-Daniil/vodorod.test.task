using Microsoft.EntityFrameworkCore;
using vodorod.test.task.data.access.Entities;
namespace vodorod.test.task.data.access
{
    /// <summary>
    /// Db контекст приложения
    /// </summary>
    public class VodorotTestTaskDbContext : DbContext
    {
        public DbSet<RateEntity> RateEntity { get; set; }
        public VodorotTestTaskDbContext(DbContextOptions<VodorotTestTaskDbContext> options) : base(options)
        {

        }
    }
}
