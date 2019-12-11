

using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Services.Interfaces
{
    public interface IHoaDonIndexVMServices
    {
        HoaDonVM GetHoaDonVM(string currentSort,int idBanAn, string trangThai, int pageIndex);
        HoaDonVM Details(int id);
    }
}