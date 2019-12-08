using System;
using System.Globalization;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyNhaHang.Controllers {
    public class LoaiMonAnController : Controller {
        private readonly ILoaiMonAnServices _services;
        public LoaiMonAnController (ILoaiMonAnServices services) {
            this._services = services;
        }

        public bool KiemTraDangNhap () {
            if (String.IsNullOrEmpty (HttpContext.Session.GetString ("TenDangNhapCurrentUser"))) {
                return false;
            } else {
                ViewBag.TenCurrentUser = HttpContext.Session.GetString ("TenCurrentUser").ToString ();
                ViewBag.IdCurrentUser = HttpContext.Session.GetString ("IdCurrentUser").ToString ();
                return true;
            }
        }

        public IActionResult Index (int pageIndex = 1) {
            if (KiemTraDangNhap () == false)
                return View ("../Login/Index");
                
            LoaiMonAnVM loaiMonAnVM = _services.GetLoaiMonAnVM (pageIndex);
            return View (loaiMonAnVM);
        }
    }
}