

using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Services.Interfaces
{
    public interface IKhachHangIndexVMServices
    {
        KhachHangVM GetKhachHangVM(string currentSort, string Ten, string SDT, string DiaChi, int pageIndex);
    }
}