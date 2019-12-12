using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.Services;
using QuanLyNhaHang.Services.Interfaces;
using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Services
{
    public class PhieuDatBanIndexVMServices : IPhieuDatBanIndexVMServices
    {
        private readonly IPhieuDatBanServices _services;
        private readonly int pageSize = 5;
        public PhieuDatBanIndexVMServices(IPhieuDatBanServices services)
        {
            _services = services;
        }
        public PhieuDatBanVM GetPhieuDatBanVM(string currentSort, int idBanAn, string trangThai, int pageIndex)
        {
            int count;
            IEnumerable<PhieuDatBanMD> listPhieuDatBanMD = _services.GetListPhieuDatBanMD(idBanAn, trangThai, pageIndex, pageSize, out count);

            switch (currentSort)
            {
                case "BanAn_ASC":
                    listPhieuDatBanMD = listPhieuDatBanMD.OrderBy(s => s.IdBanAn);
                    break;
                case "BanAn_DESC":
                    listPhieuDatBanMD = listPhieuDatBanMD.OrderByDescending(s => s.IdBanAn);
                    break;
                case "ThoiGianDat_ASC":
                    listPhieuDatBanMD = listPhieuDatBanMD.OrderBy(s => s.ThoiGianDat);
                    break;
                case "ThoiGianDat_DESC":
                    listPhieuDatBanMD = listPhieuDatBanMD.OrderByDescending(s => s.ThoiGianDat);
                    break;

                case "TrangThai_ASC":
                    listPhieuDatBanMD = listPhieuDatBanMD.OrderBy(s => s.TrangThai);
                    break;
                case "TrangThai_DESC":
                    listPhieuDatBanMD = listPhieuDatBanMD.OrderByDescending(s => s.TrangThai);
                    break;
                case "TenKhachHang_ASC":
                    listPhieuDatBanMD = listPhieuDatBanMD.OrderBy(s => s.TenKhachHang);
                    break;
                case "TenKhachHang_DESC":
                    listPhieuDatBanMD = listPhieuDatBanMD.OrderByDescending(s => s.TenKhachHang);
                    break;


            }
            return new PhieuDatBanVM
            {
                PhieuDatBans = new PaginatedList<PhieuDatBanMD>(listPhieuDatBanMD, pageIndex, pageSize, count)
            };
        }
    }
}