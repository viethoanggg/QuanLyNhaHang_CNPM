using System.Reflection.Metadata;
using ApplicationCore.Entitites;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Services;
using QuanLyNhaHang.Services.Interfaces;

namespace QuanLyNhaHang.Controllers
{
    public class HoaDonController : Controller
    {
        private readonly IHoaDonServices _services;
        public HoaDonController(IHoaDonServices services)
        {
            this._services = services;
        }
        public IActionResult Index(int pageIndex=1)
        {
            return View(_services.GetHoaDonVM(pageIndex));
        }
        public IActionResult Delete(int? id)
        {
            if(id==null)
                return RedirectToAction("Index");
            HoaDon hoaDon=_services.FindHD(id.Value);
            if(hoaDon==null)
                return RedirectToAction("Index");
            return View(hoaDon);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Deleted(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            HoaDon hoaDon = _services.FindHD(id.Value);    
            if (hoaDon == null)
                return RedirectToAction("Index");

            BanAn ba = _services.FindBanAn(id.Value);

            if(ba.TrangThai.Equals("Đang phục vụ"))
            {
                ViewBag.Error = "Bàn ăn đang được phục vụ ,không thể xóa ";
                return View(hoaDon);
            }
            _services.Delete(hoaDon);
            return RedirectToAction("Index");
        }

        public IActionResult Detalis(int? id )
        {
            if (id == null)
                return RedirectToAction("Index");
            HoaDon hoaDon = _services.FindHD(id.Value);
            if (hoaDon == null)
                return RedirectToAction("Index");
            return View(hoaDon);
        }
    }
}