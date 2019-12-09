using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;

namespace ApplicationCore.Interfaces.IServices
{
    public interface INguoiDungServices
    {
        IEnumerable<NguoiDungDTO> GetListNguoiDung(string Ten, string TenDangNhap, string VaiTro, int TrangThai, int pageIndex, int pageSize, out int count);
        NguoiDungDTO GetNguoiDung(int id);
        SaveNguoiDungDTO GetSaveNguoiDungDTO(int id);
        void Edit(SaveNguoiDungDTO NguoiDung);
        void Create(SaveNguoiDungDTO NguoiDung);
        
    }
}