using System.Collections.Generic;
using ApplicationCore.Entitites;

namespace QuanLyNhaHang.Services.Interfaces
{
    public interface IHoaDonServices
    {
        PaginatedList<HoaDon> GetHoaDonVM(int pageIndex);
        HoaDon FindHD(int id);
        void Delete(HoaDon HoaDon);
        BanAn FindBanAn(int IdHoaDon);

    }
}