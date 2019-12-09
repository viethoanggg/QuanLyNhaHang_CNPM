using ApplicationCore.ModelsContainData.ViewModels;

namespace QuanLyNhaHang.Services.Interfaces
{
    public interface IThucDonIndexVMServices
    {
        ThucDonVM GetThucDonVM(string searchString, string searchStringGiaTu, string searchStringGiaDen, string currentSort, int pageIndex);
    }
}