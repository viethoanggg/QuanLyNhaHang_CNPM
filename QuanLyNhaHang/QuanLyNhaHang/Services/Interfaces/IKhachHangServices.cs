using ApplicationCore.Entitites;
using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Services.Interfaces
{
    public interface IKhachHangServices
    {
        KhachHangVM GetKhachHangVM(int pageIndex);
        KhachHang GetKhachHang(int id);
        void Edit(KhachHang khachHang);
        void Create(KhachHang khachHang);
        void Delete(int id);


    }
}