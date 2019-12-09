using System.Collections.Generic;
using System.Linq;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.ViewModels;
using ApplicationCore.Services;
using QuanLyNhaHang.Services.Interfaces;

namespace QuanLyNhaHang.Services
{
    public class NguoiDungIndexVMServices : INguoiDungIndexVMServices
    {
        private readonly INguoiDungServices _services;
        private readonly int pageSize = 10;
        public NguoiDungIndexVMServices(INguoiDungServices services)
        {
            _services = services;
        }
        public NguoiDungVM GetNguoiDungVM(string currentSort, string Ten, string TenDangNhap, string VaiTro, int TrangThai, int pageIndex)
        {
            int count;
            IEnumerable<NguoiDungDTO> listNguoiDung = _services.GetListNguoiDung(Ten, TenDangNhap, VaiTro, TrangThai, pageIndex, pageSize, out count);
            switch (currentSort)
            {
                case "Ten_ASC":
                    listNguoiDung = listNguoiDung.OrderBy(s => s.Ten);
                    break;
                case "Ten_DESC":
                    listNguoiDung = listNguoiDung.OrderByDescending(s => s.Ten);
                    break;
                case "TenDangNhap_ASC":
                    listNguoiDung = listNguoiDung.OrderBy(s => s.TenDangNhap);
                    break;
                case "TenDangNhap_DESC":
                    listNguoiDung = listNguoiDung.OrderByDescending(s => s.TenDangNhap);
                    break;
                case "VaiTro_ASC":
                    listNguoiDung = listNguoiDung.OrderBy(s => s.Role);
                    break;
                case "VaiTro_DESC":
                    listNguoiDung = listNguoiDung.OrderByDescending(s => s.Role);
                    break;
                case "TrangThai_ASC":
                    listNguoiDung = listNguoiDung.OrderBy(s => s.TrangThai);
                    break;
                case "TrangThai_DESC":
                    listNguoiDung = listNguoiDung.OrderByDescending(s => s.TrangThai);
                    break;

            }
            return new NguoiDungVM
            {
                NguoiDungs = new PaginatedList<NguoiDungDTO>(listNguoiDung, pageIndex, pageSize, count)
            };
        }
    }
}