using System.Reflection.Emit;
using ApplicationCore.Entitites;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Services;

namespace QuanLyNhaHang.ViewModels
{
    public class HoaDonVM
    {
        public PaginatedList<HoaDon> HoaDons{ get; set; }
        public CTHDMD ChiTietHoaDonMD{ get; set; }
    }
}