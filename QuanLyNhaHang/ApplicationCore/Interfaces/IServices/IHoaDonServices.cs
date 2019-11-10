using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.ModelsContainData.ViewModels;
using ApplicationCore.Services;

namespace ApplicationCore.Interfaces.IServices {
    public interface IHoaDonServices {
        HoaDonVM GetHoaDonVM (int pageIndex);
        HoaDonDTO FindHD (int id);
        void Delete (SaveHoaDonDTO HoaDon);
        BanAnDTO FindBanAn (int IdHoaDon);
        void Edit (SaveHoaDonDTO saveHoaDonDTO);
        IEnumerable<BanAnDTO> GetListBanAn ();
        HoaDonVM Details (int id);
        string GetNameUser (int IdUser);
    }
}