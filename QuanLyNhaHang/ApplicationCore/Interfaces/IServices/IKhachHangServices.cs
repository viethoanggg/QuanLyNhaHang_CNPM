using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entitites;
using ApplicationCore.ModelsContainData.ViewModels;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IKhachHangServices
    {
        KhachHangVM GetKhachHangVM(int pageIndex);
        KhachHangDTO GetKhachHang(int id);
        void Edit(SaveKhachHangDTO khachHang);
        void Create(SaveKhachHangDTO khachHang);
        void Delete(int id);


    }
}