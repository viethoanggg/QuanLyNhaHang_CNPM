using System.Collections.Generic;
using ApplicationCore.Entitites;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Services.Interfaces
{
    public interface IBanAnServices
    {
        BanAnVM GetBanAnVM(int pageIndex);
        BanAn GetBanAn(int id);
        void Edit(BanAn banAn);
        void Delete(int id);
        void Create(BanAn banAn);
        HoaDon CreateBill(HoaDon hoaDon);
        HoaDon FindHD(int IdBanAn);
        void SetTrangThaiBanAn(int Id, string trangThai);
        void ThanhToan(HoaDon HoaDon);
        IEnumerable<LoaiMonAn> GetListLoaiMonAn();
        PaginatedList<ThucDon> GetListMonAn(int? IdLoaiMonAn,int pageIndex);
        void ThemCTDH(int IdHoaDon, int IdMonAn, int SoLuong);
        IEnumerable<ChiTietHoaDon> GetListCTHD(int IdHoaDon);
        IEnumerable<CTHDMD> GetListCTHDMD(int IdHoaDon);
        HoaDon CapNhatThanhTien(HoaDon HoaDon);
        HoaDon GetHDById(int IdHoaDon);
        void SetTrangThaiPhieuDatBan(int Id);
    }
}