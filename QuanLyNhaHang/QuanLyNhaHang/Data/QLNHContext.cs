using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Models;

namespace QuanLyNhaHang.Data
{
    public class QLNHContext : DbContext
    {
        public QLNHContext(DbContextOptions<QLNHContext> options) : base(options)
        {

        }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
    }
}