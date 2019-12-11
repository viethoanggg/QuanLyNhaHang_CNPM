using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entities;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.Services;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IBanAnServices
    {
        IEnumerable<BanAnDTO> GetListBanAn(string trangThai, int pageIndex, int pageSize, out int count);
        BanAnDTO GetBanAn(int id);
        void Edit(SaveBanAnDTO banAn);
        int Delete(int id);
        void Create(SaveBanAnDTO banAn);
        HoaDonDTO CreateBill(SaveHoaDonDTO SaveHoaDonDTO);
        HoaDonDTO FindHD(int IdBanAn);
        void SetTrangThaiBanAn(int Id, string trangThai);
        void ThanhToan(int IdHoaDon, int IdUser);
        IEnumerable<LoaiMonAnDTO> GetListLoaiMonAn();
        PaginatedList<ThucDonDTO> GetListMonAn(int? IdLoaiMonAn, int pageIndex);
        Task ThemCTHD(int IdHoaDon, int IdMonAn, int SoLuong);
        IEnumerable<CTHDMD> GetListCTHDMD(int IdHoaDon);
        HoaDonDTO CapNhatThanhTien(int id);
        HoaDon GetHDById(int IdHoaDon);
        void SetTrangThaiPhieuDatBan(int Id);
        ThucDon GetMonAn(int IdMonAn);
        void DeleteCTHD(int IdHoaDon, int IdMonAn);
    }
}