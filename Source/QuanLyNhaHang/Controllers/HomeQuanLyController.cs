using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Interfaces.IServices;
using QuanLyNhaHang.Services.Interfaces;
using ApplicationCore.DTOs;

namespace QLNH.Controllers
{

    public class HomeQuanLyController : Controller
    {
        // GET: QuanLy/HomeQuanLy
        private readonly INguoiDungServices _services;
        private readonly INguoiDungIndexVMServices _servicesIndexVM;
        public HomeQuanLyController(INguoiDungServices services, INguoiDungIndexVMServices servicesIndexVM)
        {
            this._services = services;
            this._servicesIndexVM = servicesIndexVM;
        }
        public IActionResult Index()
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            int id = Convert.ToInt32(HttpContext.Session.GetString("IdCurrentUser").ToString());
            NguoiDungDTO nguoiDung = _services.GetNguoiDung(id);
            ViewBag.Time = DateTime.Now;
            return View(nguoiDung);
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
    }
}