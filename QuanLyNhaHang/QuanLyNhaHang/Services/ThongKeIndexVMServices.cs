using System;
using System.Collections.Generic;
using System.Linq;
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
        public ThongKeVM GetThongKeVM(string currentSort,DateTime thoiGianTu, DateTime thoiGianDen, int pageIndex)
        {
            IEnumerable<ThongKeSLMonAnMD> listThongKe = _services.GetListMonAnBanDuoc(thoiGianTu, thoiGianDen);
           
            int tongDoanhThu = _services.GetThongKeTongDoanhThu(thoiGianTu, thoiGianDen);
            int tongBanAnDuocPhucVu = _services.GetTongSoBanDuocPhucVu(thoiGianTu, thoiGianDen);
            int tongPhieuDatBan = _services.GetThongKeTongPhieuDatBan(thoiGianTu, thoiGianDen);
            int tongPhieuDatBanBiHuy = _services.GetThongKePhieuDatBanBiHuy(thoiGianTu, thoiGianDen);
            int tongPhieuDatBanXuLyXong = _services.GetThongKePhieuDatBanXuLyXong(thoiGianTu, thoiGianDen);
            int tongPhieuDatBanChuaXuLy = _services.GetThongKePhieuDatBanChuaXuLy(thoiGianTu, thoiGianDen);

            switch(currentSort)
            {
                case "TenMonAn_ASC":
                    listThongKe = listThongKe.OrderBy(s => s.Ten);
                    break;
                case "TenMonAn_DESC":
                    listThongKe = listThongKe.OrderByDescending(s => s.Ten);
                    break;
                case "TenLoaiMonAn_ASC":
                    listThongKe = listThongKe.OrderBy(s => s.TenLoaiMonAn);
                    break;
                case "TenLoaiMonAn_DESC":
                    listThongKe = listThongKe.OrderByDescending(s => s.TenLoaiMonAn);
                    break;
                case "Gia_ASC":
                    listThongKe = listThongKe.OrderBy(s => s.Gia);
                    break;
                case "Gia_DESC":
                    listThongKe = listThongKe.OrderByDescending(s => s.Gia);
                    break;
                case "SLBanDuoc_ASC":
                    listThongKe = listThongKe.OrderBy(s => s.SoLuongBanDuoc);
                    break;
                case "SLBanDuoc_DESC":
                    listThongKe = listThongKe.OrderByDescending(s => s.SoLuongBanDuoc);
                    break;
            }
            
            PaginatedList<ThongKeSLMonAnMD> list = PaginatedList<ThongKeSLMonAnMD>.Create(listThongKe, pageIndex, pageSize);
            return new ThongKeVM
            {
                ListMonAnBanDuoc = list,
                TongDoanhThu = tongDoanhThu,
                TongSoPhieuDatBan = tongPhieuDatBan,
                TongPhieuDatBanBiHuy = tongPhieuDatBanBiHuy,
                TongPhieuDatBanXuLyXong = tongPhieuDatBanXuLyXong,
                TongSoBanAnDuocPhucVu = tongBanAnDuocPhucVu,
                TongPhieuDatBanChuaXuLy = tongPhieuDatBanChuaXuLy
            };
        }

    }
}