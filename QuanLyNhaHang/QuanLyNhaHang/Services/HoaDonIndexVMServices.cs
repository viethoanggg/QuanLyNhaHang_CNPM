using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.ModelsContainData.ViewModels;
using ApplicationCore.Services;
using QuanLyNhaHang.Services.Interfaces;

namespace QuanLyNhaHang.Services
{
    public class HoaDonIndexVMServices : IHoaDonIndexVMServices
    {
        private readonly IHoaDonServices _services;
        private readonly int pageSize = 10;
        public HoaDonIndexVMServices(IHoaDonServices services)
        {
            _services = services;
        }
        public HoaDonVM GetHoaDonVM(string currentSort, int idBanAn, string trangThai, int pageIndex)
        {
            int count;
            IEnumerable<HoaDonMD> listHoaDonMD = _services.GetListHoaDonMD(idBanAn, trangThai, pageIndex, pageSize, out count);

            switch (currentSort)
            {
                case "BanAn_ASC":
                    listHoaDonMD = listHoaDonMD.OrderBy(s => s.IdBanAn);
                    break;
                case "BanAn_DESC":
                    listHoaDonMD = listHoaDonMD.OrderByDescending(s => s.IdBanAn);
                    break;
                case "ThoiGianLap_ASC":
                    listHoaDonMD = listHoaDonMD.OrderBy(s => s.ThoiGianLap);
                    break;
                case "ThoiGianLap_DESC":
                    listHoaDonMD = listHoaDonMD.OrderByDescending(s => s.ThoiGianLap);
                    break;
                case "ThoiGianThanhToan_ASC":
                    listHoaDonMD = listHoaDonMD.OrderBy(s => s.ThoiGianThanhToan);
                    break;
                case "ThoiGianThanhToan_DESC":
                    listHoaDonMD = listHoaDonMD.OrderByDescending(s => s.ThoiGianThanhToan);
                    break;
                case "TrangThai_ASC":
                    listHoaDonMD = listHoaDonMD.OrderBy(s => s.TrangThai);
                    break;
                case "TrangThai_DESC":
                    listHoaDonMD = listHoaDonMD.OrderByDescending(s => s.TrangThai);
                    break;
                case "TenNhanVien_ASC":
                    listHoaDonMD = listHoaDonMD.OrderBy(s => s.TenNhanVien);
                    break;
                case "TenNhanVien_DESC":
                    listHoaDonMD = listHoaDonMD.OrderByDescending(s => s.TenNhanVien);
                    break;
                case "ThanhTien_ASC":
                    listHoaDonMD = listHoaDonMD.OrderBy(s => s.ThanhTien);
                    break;
                case "ThanhTien_DESC":
                    listHoaDonMD = listHoaDonMD.OrderByDescending(s => s.ThanhTien);
                    break;
                case "IdHoaDon_ASC":
                    listHoaDonMD = listHoaDonMD.OrderBy(s => s.Id);
                    break;
                case "IdHoaDon_DESC":
                    listHoaDonMD = listHoaDonMD.OrderByDescending(s => s.Id);
                    break;
            }
            return new HoaDonVM
            {
                ListHoaDonMD = new PaginatedList<HoaDonMD>(listHoaDonMD, pageIndex, pageSize, count)
            };
        }
    }
}