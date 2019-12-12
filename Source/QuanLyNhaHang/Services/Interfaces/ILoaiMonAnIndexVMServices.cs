

using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Services.Interfaces
{
    public interface ILoaiMonAnIndexVMServices
    {
        LoaiMonAnVM GetLoaiMonAnVM(string currentSort, string searchString, int pageIndex);
    }
}