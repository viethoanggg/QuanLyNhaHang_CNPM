
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ChiTietHoaDonConfiguration : IEntityTypeConfiguration<ChiTietHoaDon>
    {

        public void Configure(EntityTypeBuilder<ChiTietHoaDon> builder)
        {
            builder.Property(m => m.IdHoaDon)
                    .IsRequired(true);

            builder.Property(m => m.IdMonAn)
                    .IsRequired(true);

            builder.Property(m => m.SoLuong);

            builder.Property(m => m.DonGia);

        }
    }
}