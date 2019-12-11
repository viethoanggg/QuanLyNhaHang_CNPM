using ApplicationCore.DTOs;
using ApplicationCore.Services;

namespace QuanLyNhaHang.ViewModels
{
    public class NguoiDungVM
    {
        public PaginatedList<NguoiDungDTO> NguoiDungs { get; set; }
    }
}