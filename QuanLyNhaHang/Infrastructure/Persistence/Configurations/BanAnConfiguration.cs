
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class BanAnConfiguration : IEntityTypeConfiguration<BanAn>
    {

        public void Configure(EntityTypeBuilder<BanAn> builder)
        {
            builder.Property(m => m.LoaiBanAn)
                    .IsRequired();
            builder.Property(m => m.TrangThai);

            builder.Property(m => m.GhiChu);

        }
    }
}