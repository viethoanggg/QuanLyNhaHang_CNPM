using ApplicationCore.DTOs;
using ApplicationCore.Services;

namespace QuanLyNhaHang.ViewModels
{
    public class BanAnVM
    {
        public PaginatedList<BanAnDTO> BanAns{ get; set; }
    }
}