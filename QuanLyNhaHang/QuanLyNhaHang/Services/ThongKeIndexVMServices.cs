using System.Collections.Generic;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.ModelsContainData.ViewModels;
using ApplicationCore.Services;
using QuanLyNhaHang.Services.Interfaces;

namespace QuanLyNhaHang.Services
{
    public class ThongKeIndexVMServices : IThongKeIndexVMServices
    {
        private readonly IThongKeServices _services;
        private readonly int pageSize = 10;
        public ThongKeIndexVMServices(IThongKeServices services)
        {
            _services = services;
        }
        public ThongKeVM GetThongKeVM(int pageIndex)
        {
            IEnumerable<ThongKeSLMonAnMD> listThongKe = _services.GetListMonAnBanDuoc();
            PaginatedList<ThongKeSLMonAnMD> list = PaginatedList<ThongKeSLMonAnMD>.Create(listThongKe, pageIndex, pageSize);
            int tongDoanhThu = _services.GetThongKeTongDoanhThu();
            int tongBanAnDuocPhucVu = _services.GetTongSoBanDuocPhucVu();
            int tongPhieuDatBan = _services.GetThongKeTongPhieuDatBan();
            int tongPhieuDatBanBiHuy = _services.GetThongKePhieuDatBanBiHuy();
            int tongPhieuDatBanXuLyXong = _services.GetThongKePhieuDatBanXuLyXong();
            return new ThongKeVM
            {
                ListMonAnBanDuoc = list,
                TongDoanhThu = tongDoanhThu,
                TongSoPhieuDatBan = tongPhieuDatBan,
                TongPhieuDatBanBiHuy = tongPhieuDatBanBiHuy,
                TongPhieuDatBanXuLyXong = tongPhieuDatBanXuLyXong,
                TongSoBanAnDuocPhucVu = tongBanAnDuocPhucVu

            };
        }

    }
}