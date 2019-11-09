using ApplicationCore.Entitites;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Services;

namespace QuanLyNhaHang.ViewModels
{
    public class KhachHangVM
    {
        public PaginatedList<KhachHang> KhachHangs{ get; set; }
    }
}