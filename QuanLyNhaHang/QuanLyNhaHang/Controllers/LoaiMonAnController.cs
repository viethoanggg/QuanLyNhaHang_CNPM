using System;
using System.Globalization;
using ApplicationCore.Entitites;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.ViewModels;
using Microsoft.AspNetCore.Mvc;

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