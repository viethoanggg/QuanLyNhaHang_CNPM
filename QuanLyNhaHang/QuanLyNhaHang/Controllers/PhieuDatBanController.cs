using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Services.Interfaces;

namespace QuanLyNhaHang.Controllers
{
    public class PhieuDatBanController:Controller
    {
        private readonly IPhieuDatBanServices  _services;
        public PhieuDatBanController(IPhieuDatBanServices services)
        {
            this._services = services;
        }

        public IActionResult Index(int pageIndex=1)
        {
            //PhieuDatBan
            return View();
        }
    }
}