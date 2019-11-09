using ApplicationCore.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ThucDonConfiguration : IEntityTypeConfiguration<ThucDon>
    {
        public void Configure(EntityTypeBuilder<ThucDon> builder)
        {
            
        }
    }
}