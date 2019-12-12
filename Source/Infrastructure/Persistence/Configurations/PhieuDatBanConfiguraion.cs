using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class PhieuDatBanConfiguraion : IEntityTypeConfiguration<PhieuDatBan>
    {
        public void Configure(EntityTypeBuilder<PhieuDatBan> builder)
        {
            
        }
    }
}