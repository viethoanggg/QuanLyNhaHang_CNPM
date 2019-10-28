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
        public DbSet<BanAn> BanAns { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<PhieuDatBan> PhieuDatBans { get; set; }
    }
}