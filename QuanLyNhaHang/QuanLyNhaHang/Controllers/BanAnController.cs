using System;
using System.Globalization;
using ApplicationCore.Entitites;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Services;
using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Controllers
{
    public class BanAnController:Controller
    {
        private readonly IBanAnServices _services;
        public BanAnController(IBanAnServices services)
        {
            this._services = services;
        }
        public IActionResult Index(int pageIndex=1)
        {
            BanAnVM banAnVM = _services.GetBanAnVM(pageIndex);
            return View(banAnVM);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BanAn banAn)
        {
            if(ModelState.IsValid)
            {
                _services.Create(banAn);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            BanAn banAn = _services.GetBanAn(id.Value);
            return View(banAn);
        }

        [HttpPost]
        public IActionResult Edit(BanAn banAn)
        {
            if(ModelState.IsValid)
            {
                _services.Edit(banAn);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            BanAn banAn = _services.GetBanAn(id.Value);
            return View(banAn);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Deleted(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _services.Delete(id.Value);
            return RedirectToAction("Index");
        }

    
        public IActionResult Serve(int? IdBanAn,[Bind("Id","IdBanAn","IdUser","ThoiGianLap","ThoiGianThanhToan","ThanhTien")]HoaDon hoaDon)
        {
            ServeVM sv;
            if (hoaDon == null)
            {
                DateTime day = DateTime.Today;
                string s = day.ToString("MM/dd/yyyy hh:mm:ss");
                sv = new ServeVM
                {
                    DateTime = DateTime.ParseExact(s, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    IdBanAn = IdBanAn.Value 
                };
            }
            else
            {
                hoaDon.IdUser=1;
                sv = new ServeVM
                {
                    HoaDon = hoaDon,
                    IdBanAn = IdBanAn.Value
                };
            }
               
            return View(sv);
        }

        
        [HttpPost]
        public IActionResult CreateBill(HoaDon hd)
        {
            hd.IdUser = 1;
            HoaDon hoaDon = _services.CreateBill(hd);
            return RedirectToAction("Serve",hoaDon);
        }
    }
}