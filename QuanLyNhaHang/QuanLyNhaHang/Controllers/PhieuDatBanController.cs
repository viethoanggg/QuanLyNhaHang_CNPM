using System.Data;
using System;
using System.Globalization;
using System.Net;
using ApplicationCore.Entitites;
using Microsoft.AspNetCore.Mvc;

using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.ViewModels;
using AutoMapper;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;

namespace QuanLyNhaHang.Controllers
{
    public class PhieuDatBanController:Controller
    {
        private readonly IPhieuDatBanServices  _services;
        private readonly IMapper _mapper;
        public PhieuDatBanController(IPhieuDatBanServices services,IMapper mapper)
        {
            this._services = services;
            this._mapper = mapper;
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
            PhieuDatBanDTO pDTO = _services.GetById(id.Value);
            if (pDTO == null)
                return RedirectToAction("Index");
            SavePhieuDatBanDTO savePhieuDatBanDTO = _mapper.Map<PhieuDatBanDTO,SavePhieuDatBanDTO>(pDTO);
            PhieuDatBanVM vm = new PhieuDatBanVM
            {
                PhieuDatBan =savePhieuDatBanDTO,
                BanAns = _services.GetListBanAn()
            };
            return View(vm);
        } 

        [HttpPost]
        public IActionResult Edit(PhieuDatBanVM vm)
        {
            _services.Update(vm.PhieuDatBan);
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
                    PhieuDatBan = new SavePhieuDatBanDTO
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
                    PhieuDatBan = new SavePhieuDatBanDTO {
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
            SavePhieuDatBanDTO p=new SavePhieuDatBanDTO{
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
                    PhieuDatBan = new SavePhieuDatBanDTO
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
                    PhieuDatBan = new SavePhieuDatBanDTO
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
                    PhieuDatBan = new SavePhieuDatBanDTO
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
            PhieuDatBanDTO pDTO=_services.GetById(id.Value);
            if(pDTO==null)
                return RedirectToAction("Index");
            SavePhieuDatBanDTO savePhieuDatBanDTO = _mapper.Map<PhieuDatBanDTO, SavePhieuDatBanDTO>(pDTO);
            return View(savePhieuDatBanDTO);
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

        public IActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            PhieuDatBanDTO pDTO = _services.GetById(id.Value);
            if (pDTO == null)
                return RedirectToAction("Index");
            return View(pDTO);
        }
    }
}