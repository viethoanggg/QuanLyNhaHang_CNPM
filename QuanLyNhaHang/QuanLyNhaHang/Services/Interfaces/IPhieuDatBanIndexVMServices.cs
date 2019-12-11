

using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Services.Interfaces
{
    public interface IPhieuDatBanIndexVMServices
    {
        PhieuDatBanVM GetPhieuDatBanVM(string currentSort, int idBanAn, string trangThai, int pageIndex);
    }
}