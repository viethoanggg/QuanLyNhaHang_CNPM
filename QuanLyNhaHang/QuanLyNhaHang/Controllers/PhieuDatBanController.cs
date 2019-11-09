using System.Data;
using System;
using System.Globalization;
using System.Net;
using ApplicationCore.Entitites;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Services.Interfaces;
using QuanLyNhaHang.ViewModels;

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
            PhieuDatBanVM vm = _services.GetPhieuDatBanVM(pageIndex);
            return View(vm);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            PhieuDatBan p = _services.GetById(id.Value);
            if (p == null)
                return RedirectToAction("Index");
            return View(p);
        } 

        [HttpPost]
        public IActionResult Edit(PhieuDatBan p)
        {
            _services.Update(p);
            return RedirectToAction("Index");
        }

        public IActionResult Create(int? IdKhachHang)
        {
            PhieuDatBanVM vm= null;
            System.DateTime day = DateTime.Now;
            ViewBag.CurrentTime = DateTime.Now;

            if(IdKhachHang==null)
            {

                vm = new PhieuDatBanVM
                {
                    PhieuDatBan = new PhieuDatBan
                    {
                        ThoiGianDat = Convert.ToDateTime(day),
                    },
                    BanAns = _services.GetListBanAn()
                };

            }
            else
            {
                vm = new PhieuDatBanVM
                {
                    PhieuDatBan = new PhieuDatBan {
                        IdKhachHang=IdKhachHang.Value,
                        ThoiGianDat = Convert.ToDateTime(day),
                        },
                    BanAns=_services.GetListBanAn()
                };
            }

            
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(PhieuDatBanVM vm)
        {
            PhieuDatBan p=new PhieuDatBan{
                IdBanAn=vm.PhieuDatBan.IdBanAn,
                IdKhachHang=vm.PhieuDatBan.IdKhachHang,
                ThoiGianDat=vm.PhieuDatBan.ThoiGianDat,
                GhiChu=vm.PhieuDatBan.GhiChu
            };
            int i=_services.Add(p);
            
            if( i == -2 )
            {
                ViewBag.MessagePhieuDatBan = "Khách hàng này không tồn tại";
                System.DateTime day = DateTime.Now;
                vm = new PhieuDatBanVM
                {
                    PhieuDatBan = new PhieuDatBan
                    {
                        IdBanAn = vm.PhieuDatBan.IdBanAn,
                        IdKhachHang = p.IdKhachHang,
                        ThoiGianDat = Convert.ToDateTime(day),
                        GhiChu = vm.PhieuDatBan.GhiChu,
                    },
                    BanAns = _services.GetListBanAn()
                };
                return View(vm);
            }
            if (i == 0)
            {
                ViewBag.MessagePhieuDatBan = "Bàn này đã có người đặt";
                System.DateTime day = DateTime.Now;
                vm = new PhieuDatBanVM
                {
                    PhieuDatBan = new PhieuDatBan
                    {
                        IdBanAn = vm.PhieuDatBan.IdBanAn,
                        IdKhachHang = p.IdKhachHang,
                        ThoiGianDat = Convert.ToDateTime(day),
                        GhiChu = vm.PhieuDatBan.GhiChu,
                    },
                    BanAns = _services.GetListBanAn()
                };
                return View(vm);
            }
            else if (i == -1)
            {
                ViewBag.MessagePhieuDatBan = "Bàn này đang được phục vụ";
                System.DateTime day = DateTime.Now;
                vm = new PhieuDatBanVM
                {
                    PhieuDatBan = new PhieuDatBan
                    {
                        IdBanAn = vm.PhieuDatBan.IdBanAn,
                        IdKhachHang = p.IdKhachHang,
                        ThoiGianDat = Convert.ToDateTime(day),
                        GhiChu = vm.PhieuDatBan.GhiChu,
                    },
                    BanAns = _services.GetListBanAn()
                };
                return View(vm);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id==null)
                return RedirectToAction("Index");
            PhieuDatBan p=_services.GetById(id.Value);
            if(p==null)
                return RedirectToAction("Index");
            return View(p);
        }
        
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Deleted(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            PhieuDatBan p = _services.GetById(id.Value);
            if (p == null)
                return RedirectToAction("Index");
            _services.Delete(p);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            PhieuDatBan p = _services.GetById(id.Value);
            if (p == null)
                return RedirectToAction("Index");
            return View(p);
        }
    }
}