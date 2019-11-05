using ApplicationCore.Entitites;
using QuanLyNhaHang.Services;

namespace QuanLyNhaHang.ViewModels
{
    public class KhachHangVM
    {
        public PaginatedList<KhachHang> KhachHangs{ get; set; }
    }
}