using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entities;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.ModelsContainData.ViewModels;
using ApplicationCore.Services;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IBanAnServices
    {
        BanAnVM GetBanAnVM(int pageIndex);
        BanAnDTO GetBanAn(int id);
        void Edit(SaveBanAnDTO banAn);
        int Delete(int id);
        void Create(SaveBanAnDTO banAn);
        HoaDonDTO CreateBill(SaveHoaDonDTO SaveHoaDonDTO);
        HoaDonDTO FindHD(int IdBanAn);
        void SetTrangThaiBanAn(int Id, string trangThai);
        void ThanhToan(int IdHoaDon,int IdUser);
        IEnumerable<LoaiMonAnDTO> GetListLoaiMonAn();
        PaginatedList<ThucDonDTO> GetListMonAn(int? IdLoaiMonAn,int pageIndex);
        void ThemCTDH(int IdHoaDon, int IdMonAn, int SoLuong);
        IEnumerable<CTHDMD> GetListCTHDMD(int IdHoaDon);
        HoaDonDTO CapNhatThanhTien(int id);
        HoaDon GetHDById(int IdHoaDon);
        void SetTrangThaiPhieuDatBan(int Id);
    }
}