using System;
using ApplicationCore.ModelsContainData.ViewModels;

namespace QuanLyNhaHang.Services.Interfaces
{
    public interface IThongKeIndexVMServices
    {
        ThongKeVM GetThongKeVM(String currentSort,DateTime thoiGianTu, DateTime thoiGianDen,int pageIndex);
    }
}