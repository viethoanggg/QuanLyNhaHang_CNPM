using System;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Services.Interfaces;

namespace QuanLyNhaHang.Controllers
{
    public class ThongKeController : Controller
    {
        private readonly IThongKeServices _services;
        private readonly IThongKeIndexVMServices _servicesIndexVM;
        public ThongKeController(IThongKeServices services, IThongKeIndexVMServices servicesIndexVM)
        {
            this._services = services;
            this._servicesIndexVM = servicesIndexVM;
        }
        public bool KiemTraDangNhap()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("TenDangNhapCurrentUser")))
            {
                return false;
            }
            else
            {
                ViewBag.TenCurrentUser = HttpContext.Session.GetString("TenCurrentUser").ToString();
                ViewBag.IdCurrentUser = HttpContext.Session.GetString("IdCurrentUser").ToString();
                return true;
            }
        }
        public IActionResult Index(string thoiGianTu, string thoiGianDen, string currentFilterThoiGianTu, string currentFilterThoiGianDen, string currentSort, int pageIndex = 1)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");

            if (thoiGianTu != null || thoiGianDen != null)
                pageIndex = 1;
            if (thoiGianTu == null)
                thoiGianTu = currentFilterThoiGianTu;
            if (thoiGianDen == null)
                thoiGianDen = currentFilterThoiGianDen;

            ViewBag.CurrentFilterThoiGianTu = thoiGianTu;
            ViewBag.CurrentFilterThoiGianDen = thoiGianDen;

            if (String.IsNullOrEmpty(currentSort))
                currentSort = "TenLoaiMonAn_DESC";

            ViewBag.CurrentSortTenLoaiMonAn = currentSort.Equals("TenLoaiMonAn_DESC") ? "TenLoaiMonAn_ASC" : "TenLoaiMonAn_DESC";
            ViewBag.CurrentSortTenMonAn = currentSort.Equals("TenMonAn_DESC") ? "TenMonAn_ASC" : "TenMonAn_DESC";
            ViewBag.CurrentSortGia = currentSort.Equals("Gia_DESC") ? "Gia_ASC" : "Gia_DESC";
            ViewBag.CurrentSortSLBanDuoc = currentSort.Equals("SLBanDuoc_DESC") ? "SLBanDuoc_ASC" : "SLBanDuoc_DESC";

            ViewBag.CurrentSort = currentSort;
            DateTime tgTu = new DateTime();
            if (!String.IsNullOrEmpty(thoiGianTu))
                tgTu = Convert.ToDateTime(thoiGianTu);

            DateTime tgDen = DateTime.Now;
            if (!String.IsNullOrEmpty(thoiGianDen))
                tgDen = Convert.ToDateTime(thoiGianDen);

            return View(_servicesIndexVM.GetThongKeVM(currentSort, tgTu, tgDen, pageIndex));
        }
    }
}