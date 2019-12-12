using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Services.Interfaces
{
    public interface IBanAnIndexVMServices
    {
        BanAnVM GetBanAnVM(string trangThai, int pageIndex);
    }
}