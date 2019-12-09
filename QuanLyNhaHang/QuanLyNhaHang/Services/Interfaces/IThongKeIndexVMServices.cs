using ApplicationCore.ModelsContainData.ViewModels;

namespace QuanLyNhaHang.Services.Interfaces
{
    public interface IThongKeIndexVMServices
    {
        ThongKeVM GetThongKeVM(int pageIndex);
    }
}