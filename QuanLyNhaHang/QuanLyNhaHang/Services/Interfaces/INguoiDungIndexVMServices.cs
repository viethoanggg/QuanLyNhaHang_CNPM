using ApplicationCore.ModelsContainData.ViewModels;

namespace QuanLyNhaHang.Services.Interfaces
{
    public interface INguoiDungIndexVMServices
    {
        NguoiDungVM GetNguoiDungVM(string currentSort, string Ten, string TenDangNhap, string VaiTro, int TrangThai, int pageIndex);
    }
}