using ApplicationCore.DTOs;
using ApplicationCore.Services;

namespace QuanLyNhaHang.ViewModels
{
    public class KhachHangVM
    {
        public PaginatedList<KhachHangDTO> KhachHangs{ get; set; }
    }
}