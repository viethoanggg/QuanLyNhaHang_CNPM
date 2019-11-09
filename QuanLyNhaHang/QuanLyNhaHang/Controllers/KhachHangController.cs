using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.ViewModels;
using Microsoft.AspNetCore.Mvc;


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