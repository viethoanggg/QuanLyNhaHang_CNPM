using System;
using System.Globalization;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Services.Interfaces;

namespace QuanLyNhaHang.Controllers
{
    public class LoaiMonAnController : Controller
    {
        private readonly ILoaiMonAnServices _services;
        private readonly ILoaiMonAnIndexVMServices _servicesIndexVm;
        public LoaiMonAnController(ILoaiMonAnServices services, ILoaiMonAnIndexVMServices servicesIndexVM)
        {
            this._services = services;
            this._servicesIndexVm = servicesIndexVM;
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

        public IActionResult Index(string currentSort, string currentFilter, string searchString, int pageIndex = 1)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");

            if (!String.IsNullOrEmpty(searchString))
            {
                pageIndex = 1;
            }
            else
                searchString = currentFilter;

            if (String.IsNullOrEmpty(currentSort))
                currentSort = "TEN_DESC";

            
            ViewBag.CurrentSortName = currentSort.Equals("TEN_DESC") ? "TEN_ASC" : "TEN_DESC";
            ViewBag.CurrentSort = currentSort;
            ViewBag.CurrentFilter = searchString;
            LoaiMonAnVM loaiMonAnVM = _servicesIndexVm.GetLoaiMonAnVM(currentSort, searchString, pageIndex);

            return View(loaiMonAnVM);
        }
    }
}