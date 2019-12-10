using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.IServices
{
    public interface INguoiDungServices
    {
        IEnumerable<NguoiDungDTO> GetListNguoiDung(string Ten, string TenDangNhap, string VaiTro, int TrangThai, int pageIndex, int pageSize, out int count);
        NguoiDungDTO GetNguoiDung(int id);
        SaveNguoiDungDTO GetSaveNguoiDungDTO(int id);
        void Edit(SaveNguoiDungDTO NguoiDung);
        int Create(string NhapLaiMatKhau, SaveNguoiDungDTO NguoiDung);
        int LockUser(int IdUser, int IdCurrentUser);
        IEnumerable<HoaDon> GetListHDCuaNguoiDung(int idUser);

        void SuaThongTinCaNhan(int IdUser, string HoTen);

        string DoiMatKhau(int IdUser, string MatKhauMoi,string MatKhauCu);
    }
}