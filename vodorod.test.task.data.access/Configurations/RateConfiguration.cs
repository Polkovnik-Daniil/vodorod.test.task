using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using vodorod.test.task.core.Models;
using vodorod.test.task.data.access.Entities;

namespace vodorod.test.task.data.access.Configurations
{
    /// <summary>
    /// Концигурационный файл, описывающий сущность
    /// </summary>
    public class RateConfiguration : IEntityTypeConfiguration<RateEntity>
    {
        public void Configure(EntityTypeBuilder<RateEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Cur_OfficialRate).IsRequired();
            builder.Property(x => x.Cur_Abbreviation).HasMaxLength(RateModel.MAX_LENGTH).IsRequired();
            builder.Property(x => x.Cur_Scale).IsRequired();
            builder.Property(x => x.Date).IsRequired(); 
        }
    }

}
