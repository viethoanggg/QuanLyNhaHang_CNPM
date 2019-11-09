using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Services;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IHoaDonServices
    {
        PaginatedList<HoaDonDTO> GetHoaDonVM(int pageIndex);
        HoaDonDTO FindHD(int id);
        void Delete(SaveHoaDonDTO HoaDon);
        BanAnDTO FindBanAn(int IdHoaDon);

    }
}