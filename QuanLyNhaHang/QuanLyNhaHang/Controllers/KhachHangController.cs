using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Services.Interfaces;
using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Controllers
{
    public class KhachHangController:Controller
    {
        private readonly IKhachHangServices _services;
        public KhachHangController(IKhachHangServices services)
        {
            this._services = services;
        }
        public IActionResult Index(int pageIndex=1)
        {
            KhachHangVM khachHangVM = _services.GetKhachHangVM(pageIndex);
            return View(khachHangVM);
        }
    }
}