using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class KhacHangConfiguration : IEntityTypeConfiguration<SaveKhachHangDTO>
    {
        public void Configure(EntityTypeBuilder<SaveKhachHangDTO> builder)
        {
            builder.Property(m => m.Ten)
                    .IsRequired(true);

            builder.Property(m => m.SDT)
                    .IsRequired(true);

            builder.Property(m => m.DiaChi)
                    .IsRequired(true);

        }
    }
}