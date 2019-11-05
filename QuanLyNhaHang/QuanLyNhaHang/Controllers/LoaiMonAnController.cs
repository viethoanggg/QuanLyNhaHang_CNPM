using System;
using System.Globalization;
using ApplicationCore.Entitites;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Services;
using QuanLyNhaHang.Services.Interfaces;
using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Controllers
{
    public class LoaiMonAnController : Controller
    {
        private readonly ILoaiMonAnServices _services;
        public LoaiMonAnController(ILoaiMonAnServices services)
        {
            this._services = services;
        }
        public IActionResult Index(int pageIndex=1)
        {
            LoaiMonAnVM loaiMonAnVM = _services.GetLoaiMonAnVM(pageIndex);
            return View(loaiMonAnVM);
        }
    }
}