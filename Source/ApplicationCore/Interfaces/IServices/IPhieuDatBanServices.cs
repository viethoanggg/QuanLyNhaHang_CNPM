using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entities;
using ApplicationCore.ModelsContainData.Models;


namespace ApplicationCore.Interfaces.IServices
{
    public interface IPhieuDatBanServices
    {
        IEnumerable<PhieuDatBanMD> GetListPhieuDatBanMD(int IdBanAn, string trangThai, int pageIndex, int pageSize, out int count);
        PhieuDatBanDTO GetById(int Id);
        bool Update(SavePhieuDatBanDTO p);
        int Add(SavePhieuDatBanDTO p);
        void Delete(int id);
        IEnumerable<BanAnDTO> GetListBanAn();
        IEnumerable<KhachHang> GetListKH();

        KhachHang GetKhachHang(int IdKhachHang);
        NguoiDung GetNguoiDung(int IdUser);
    }
}