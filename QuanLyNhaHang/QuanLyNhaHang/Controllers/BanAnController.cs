using System.Reflection.Metadata;
using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using System.Net.Http;
using System;
using System.Globalization;
using ApplicationCore.Entitites;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Services;
using QuanLyNhaHang.ViewModels;
using System.Collections.Generic;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Services.Interfaces;

namespace QuanLyNhaHang.Controllers
{
    public class BanAnController : Controller
    {
        private readonly IBanAnServices _services;
        public BanAnController(IBanAnServices services)
        {
            this._services = services;
        }
        public IActionResult Index(int pageIndex = 1)
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
            if (ModelState.IsValid)
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
            if (ModelState.IsValid)
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


        public IActionResult Serve(int IdBanAn, int? IdLoaiMonAn, int pageIndex = 1)
        {
            ServeVM sv = null;
            BanAn ba = _services.GetBanAn(IdBanAn);
            if (ba == null)
                RedirectToAction("Index");
            if ((ba.TrangThai.Equals("Trống") || ba.TrangThai.Equals("Đã được đặt")))
            {
                System.DateTime day = DateTime.Today;
                string s = day.ToString("MM/dd/yyyy hh:mm:ss");
                sv = new ServeVM
                {
                    BanAn = ba,
                    HoaDon = new HoaDon
                    {
                        IdBanAn = IdBanAn,
                        IdUser = 1,
                        ThoiGianLap = DateTime.ParseExact(s, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                        ThoiGianThanhToan = null,
                        ThanhTien = null,
                        TrangThai = "Trống",

                    }
                };
            }
            else
            {
                // if(HoaDon.TrangThai=="Chưa thanh toán")
                HoaDon HoaDon = _services.FindHD(ba.Id);
                IEnumerable<CTHDMD> list = _services.GetListCTHDMD(HoaDon.Id);
                sv = new ServeVM
                {
                    BanAn = ba,
                    HoaDon = HoaDon,
                    LoaiMonAns = _services.GetListLoaiMonAn(),
                    ThucDons = _services.GetListMonAn(IdLoaiMonAn, pageIndex),
                    ChiTietHoaDons = list
                };

            }

            return View(sv);
        }


        [HttpPost]
        public IActionResult CreateBill([Bind("Id", "IdBanAn", "IdUser", "ThoiGianLap", "ThoiGianThanhToan", "ThanhTien", "TrangThai")]HoaDon HoaDon)
        {

            HoaDon = _services.CreateBill(HoaDon);
            _services.SetTrangThaiBanAn(HoaDon.IdBanAn, "Đang phục vụ");

            return RedirectToAction("Serve", "BanAn", HoaDon);
        }

        [HttpPost]
        public IActionResult ThanhToan(HoaDon HoaDon)
        {

            // _services.SetTrangThaiBanAn(HoaDon.IdBanAn, "Trống");
            // _services.ThanhToan(HoaDon);
            // return RedirectToAction("Index");
            System.DateTime day = DateTime.Today;
            string s = day.ToString("MM/dd/yyyy HH:mm:ss");
            HoaDon.ThoiGianThanhToan = DateTime.ParseExact(s, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            return View(HoaDon);
        }

        public IActionResult ExeThanhToan(int id)
        {

            HoaDon HoaDon = _services.GetHDById(id);
            if(HoaDon==null)
                return RedirectToAction("Index");
            if (HoaDon.TrangThai!="Chưa thanh toán")
                return RedirectToAction("Index");
            System.DateTime day = DateTime.Today;
            string s = day.ToString("MM/dd/yyyy HH:mm:ss");
            HoaDon.ThoiGianThanhToan = DateTime.ParseExact(s, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            _services.SetTrangThaiBanAn(HoaDon.IdBanAn, "Trống");
            _services.ThanhToan(HoaDon);
            return RedirectToAction("Index");
           
        }
        
        public IActionResult GetLoaiMonAn(int IdBanAn, int? IdLoaiMonAn, int pageIndex = 1)
        {
            
            ServeVM sv = null;
            BanAn ba = _services.GetBanAn(IdBanAn);
            HoaDon HoaDon = _services.FindHD(ba.Id);
            IEnumerable<CTHDMD> list = _services.GetListCTHDMD(HoaDon.Id);

            sv = new ServeVM
            {
                BanAn = ba,
                HoaDon = HoaDon,
                LoaiMonAns = _services.GetListLoaiMonAn(),
                ThucDons = _services.GetListMonAn(IdLoaiMonAn, pageIndex),
                ChiTietHoaDons = list,

            };

            return PartialView("_TDPartial",sv);
        }

        public IActionResult ThemCTHD(int IdHoaDon, int IdLoaiMonAn, int IdBanAn,int IdMonAn,int SoLuong,int pageIndex=1)
        {
            
            ServeVM sv = null;
            _services.ThemCTDH(IdHoaDon, IdMonAn, SoLuong);
            BanAn ba = _services.GetBanAn(IdBanAn);
            HoaDon  h= _services.FindHD(ba.Id);
            HoaDon HoaDon=_services.CapNhatThanhTien(h);
            
            IEnumerable<CTHDMD> list = _services.GetListCTHDMD(HoaDon.Id);
            sv = new ServeVM
            {
                BanAn = ba,
                HoaDon = HoaDon,
                LoaiMonAns = _services.GetListLoaiMonAn(),
                ThucDons = _services.GetListMonAn(IdLoaiMonAn, pageIndex),
                ChiTietHoaDons = list
            };
            return PartialView("_CTHDPartial", sv);
        }
    }
}