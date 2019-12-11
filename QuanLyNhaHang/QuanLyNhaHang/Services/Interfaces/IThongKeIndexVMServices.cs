using System;
using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Services.Interfaces
{
    public interface IThongKeIndexVMServices
    {
        ThongKeVM GetThongKeVM(String currentSort,DateTime thoiGianTu, DateTime thoiGianDen,int pageIndex);
    }
}