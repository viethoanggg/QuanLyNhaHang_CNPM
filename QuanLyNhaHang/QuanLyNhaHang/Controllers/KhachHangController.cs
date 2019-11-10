using System;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyNhaHang.Controllers {
    public class KhachHangController : Controller {
        private readonly IKhachHangServices _services;
        public KhachHangController (IKhachHangServices services) {
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

            KhachHangVM khachHangVM = _services.GetKhachHangVM (pageIndex);
            return View (khachHangVM);
        }
    }
}