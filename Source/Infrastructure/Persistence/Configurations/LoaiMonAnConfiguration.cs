using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class LoaiMonAnConfiguration : IEntityTypeConfiguration<LoaiMonAn>
    {
        public void Configure(EntityTypeBuilder<LoaiMonAn> builder)
        {
            builder.Property(m => m.Ten)
                     .IsRequired(true);
        }
    }
}