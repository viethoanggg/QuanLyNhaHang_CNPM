using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.ModelsContainData.ViewModels;
using ApplicationCore.Services;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IHoaDonServices
    {
        IEnumerable<HoaDonMD> GetListHoaDonMD(int IdBanAn, string trangThai, int pageIndex, int pageSize, out int count);
        HoaDonDTO FindHD(int id);
        int Delete(int IdHoaDon);
        BanAnDTO FindBanAn(int IdHoaDon);
        void Edit(SaveHoaDonDTO saveHoaDonDTO);
        IEnumerable<BanAnDTO> GetListBanAn();
        HoaDonVM Details(int id);
        string GetNameUser(int IdUser);
    }
}