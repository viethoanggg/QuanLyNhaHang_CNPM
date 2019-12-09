using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.ModelsContainData.ViewModels;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IKhachHangServices
    {
        IEnumerable<KhachHangDTO> GetlistKhachHang(string Ten, string SDT, string DiaChi, int pageIndex, int pageSize, out int count);
        KhachHangDTO GetKhachHang(int id);
        SaveKhachHangDTO GetSaveKhachHangDTO(int id);
        void Edit(SaveKhachHangDTO khachHang);
        void Create(SaveKhachHangDTO khachHang);
        int Delete(int id);


    }
}