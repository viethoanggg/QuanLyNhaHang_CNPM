using ApplicationCore.Entitites;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Data
{
    public class QLNHContext : DbContext
    {
        public QLNHContext(DbContextOptions<QLNHContext> options) : base(options)
        {

        }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<ThucDon> ThucDons { get; set; }
        public DbSet<LoaiMonAn> LoaiMonAns { get; set; }
    }
}