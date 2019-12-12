using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ThucDonConfiguration : IEntityTypeConfiguration<ThucDon>
    {
        public void Configure(EntityTypeBuilder<ThucDon> builder)
        {
            builder.Property(m => m.Ten)
                    .HasMaxLength(50)
                    .HasAnnotation("MinLength",2)
                    .IsRequired(true);
                    
            builder.Property(m => m.Gia)
                    .IsRequired(true)
                    .HasAnnotation("Range", (0, 5000000));

        }
    }
}