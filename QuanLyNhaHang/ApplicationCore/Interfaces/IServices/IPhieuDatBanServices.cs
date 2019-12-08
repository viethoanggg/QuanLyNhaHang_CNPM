using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entities;
using ApplicationCore.ModelsContainData.ViewModels;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IPhieuDatBanServices
    {
        PhieuDatBanVM GetPhieuDatBanVM(int pageIndex);
        PhieuDatBanDTO GetById(int Id);
        bool Update(SavePhieuDatBanDTO p);
        int Add(SavePhieuDatBanDTO p);
        void Delete(int id);
        IEnumerable<BanAnDTO> GetListBanAn();
        IEnumerable<KhachHang> GetListKH();

        KhachHang GetKhachHang(int IdKhachHang);
    }
}