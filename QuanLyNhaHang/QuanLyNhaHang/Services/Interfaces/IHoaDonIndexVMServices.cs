using ApplicationCore.ModelsContainData.ViewModels;

namespace QuanLyNhaHang.Services.Interfaces
{
    public interface IHoaDonIndexVMServices
    {
        HoaDonVM GetHoaDonVM(string currentSort,int idBanAn, string trangThai, int pageIndex);
    }
}