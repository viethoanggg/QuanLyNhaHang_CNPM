using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.ComTypes;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.ModelsContainData.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyNhaHang.Controllers
{
    public class BanAnController : Controller
    {
        private readonly IBanAnServices _services;
        private readonly IMapper _mapper;
        public BanAnController(IBanAnServices services, IMapper mapper)
        {
            this._services = services;
            this._mapper = mapper;
        }
        public bool KiemTraDangNhap()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("TenDangNhapCurrentUser")))
            {
                return false;
            }
            else
            {
                ViewBag.IdCurrentUser = HttpContext.Session.GetString("IdCurrentUser").ToString();
                ViewBag.TenCurrentUser = HttpContext.Session.GetString("TenCurrentUser").ToString();
                return true;
            }
        }
        public IActionResult Index(int pageIndex = 1)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            BanAnVM banAnVM = _services.GetBanAnVM(pageIndex);
            return View(banAnVM);
        }
        public IActionResult Create()
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            return View();
        }

        [HttpPost]
        public IActionResult Create(SaveBanAnDTO SaveBanAnDTO)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (ModelState.IsValid)
            {
                _services.Create(SaveBanAnDTO);
            }
            else
            {
                return View();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (id == null)
                return RedirectToAction("Index");
            BanAnDTO banAnDTO = _services.GetBanAn(id.Value);
            SaveBanAnDTO saveBanAnDTO = _mapper.Map<BanAnDTO, SaveBanAnDTO>(banAnDTO);
            return View(saveBanAnDTO);
        }

        [HttpPost]
        public IActionResult Edit(SaveBanAnDTO SaveBanAnDTO)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (ModelState.IsValid)
            {
                _services.Edit(SaveBanAnDTO);
            }
            else
            {
                return View(SaveBanAnDTO);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (id == null)
                return RedirectToAction("Index");
            BanAnDTO banAnDTO = _services.GetBanAn(id.Value);
            SaveBanAnDTO saveBanAnDTO = _mapper.Map<BanAnDTO, SaveBanAnDTO>(banAnDTO);
            return View(saveBanAnDTO);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Deleted(int? id)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (id == null)
                return RedirectToAction("Index");
            int i = _services.Delete(id.Value);
            if (i == 0)
            {
                ViewBag.MessageDelBanAn = "Không thể xóa bàn này, bàn này đang được phục vụ hoặc đã được đặt trước";
                BanAnDTO banAnDTO = _services.GetBanAn(id.Value);
                SaveBanAnDTO saveBanAnDTO = _mapper.Map<BanAnDTO, SaveBanAnDTO>(banAnDTO);
                return View(saveBanAnDTO);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Serve(int? IdBanAn, int? IdLoaiMonAn, int? IdPhieuDatBan, int pageIndex = 1)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            ServeVM sv = null;
            if (IdBanAn == null)
                return RedirectToAction("Index");
            BanAnDTO baDTO = _services.GetBanAn(IdBanAn.Value);
            if (baDTO == null)
                RedirectToAction("Index");
            if (IdPhieuDatBan == null)
                IdPhieuDatBan = 0;
            if ((baDTO.TrangThai.Equals("Trống") || baDTO.TrangThai.Equals("Được đặt trước")))
            {
                System.DateTime day = DateTime.Now;

                sv = new ServeVM
                {
                    BanAn = baDTO,
                    IdPhieuDatBan = IdPhieuDatBan.Value,
                    HoaDon = new SaveHoaDonDTO
                    {
                        IdBanAn = IdBanAn.Value,
                        IdUser = Convert.ToInt32(HttpContext.Session.GetString("IdCurrentUser")),
                        ThoiGianLap = Convert.ToDateTime(day),
                        ThoiGianThanhToan = null,
                        ThanhTien = 0,
                        TrangThai = "Trống",
                    }
                };
            }
            else
            {
                // if(HoaDon.TrangThai=="Chưa thanh toán")
                HoaDonDTO HoaDonDTO = _services.FindHD(baDTO.Id);
                SaveHoaDonDTO saveHoaDonDTO = _mapper.Map<HoaDonDTO, SaveHoaDonDTO>(HoaDonDTO);
                IEnumerable<CTHDMD> list = _services.GetListCTHDMD(HoaDonDTO.Id);
                saveHoaDonDTO.IdUser = Convert.ToInt32(HttpContext.Session.GetString("IdCurrentUser"));
                sv = new ServeVM
                {
                    BanAn = baDTO,
                    HoaDon = saveHoaDonDTO,
                    LoaiMonAns = _services.GetListLoaiMonAn(),
                    ThucDons = _services.GetListMonAn(IdLoaiMonAn, pageIndex),
                    ChiTietHoaDons = list
                };

            }

            return View(sv);
        }

        [HttpPost]
        public IActionResult CreateBill(int? IdPhieuDatBan, ServeVM vm) //[Bind("Id", "IdBanAn", "IdUser", "ThoiGianLap", "ThoiGianThanhToan", "ThanhTien", "TrangThai")]SaveHoaDonDTO SaveHoaDonDTO)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (IdPhieuDatBan != null)
            {
                _services.SetTrangThaiPhieuDatBan(IdPhieuDatBan.Value);
            }
            SaveHoaDonDTO SaveHoaDonDTO = new SaveHoaDonDTO
            {
                IdBanAn = vm.HoaDon.IdBanAn,
                IdUser = vm.HoaDon.IdUser,
                ThoiGianLap = vm.HoaDon.ThoiGianLap,
                ThoiGianThanhToan = vm.HoaDon.ThoiGianThanhToan,
                TrangThai = vm.HoaDon.TrangThai,
                ThanhTien = vm.HoaDon.ThanhTien,
            };
            HoaDonDTO hoaDonDTO = _services.CreateBill(SaveHoaDonDTO);
            SaveHoaDonDTO saveHoaDonDTO = _mapper.Map<HoaDonDTO, SaveHoaDonDTO>(hoaDonDTO);
            return RedirectToAction("Serve", "BanAn", saveHoaDonDTO);
        }

        [HttpPost]
        public IActionResult ThanhToan(ServeVM vm)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            SaveHoaDonDTO saveHoaDonDTO = vm.HoaDon;
            System.DateTime day = DateTime.Now;
            saveHoaDonDTO.ThoiGianThanhToan = Convert.ToDateTime(day);
            return View(saveHoaDonDTO);
        }

        public IActionResult ExeThanhToan(int? id)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (id == null)
                return RedirectToAction("Index");
            //  System.DateTime day = DateTime.Now;
            // string s = day.ToString("MM/dd/yyyy HH:mm:ss");
            // HoaDon.ThoiGianThanhToan = DateTime.ParseExact(s, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            //  HoaDonDTO.ThoiGianThanhToan = Convert.ToDateTime(day);
            int iduser = Convert.ToInt32(HttpContext.Session.GetString("IdCurrentUser"));
            _services.ThanhToan(id.Value, iduser);
            return RedirectToAction("Index");

        }

        public IActionResult GetLoaiMonAn(int IdBanAn, int? IdLoaiMonAn, int pageIndex = 1)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            ServeVM sv = null;
            BanAnDTO baDTO = _services.GetBanAn(IdBanAn);
            HoaDonDTO HoaDonDTO = _services.FindHD(baDTO.Id);
            IEnumerable<CTHDMD> list = _services.GetListCTHDMD(HoaDonDTO.Id);
            SaveHoaDonDTO saveHoaDonDTO = _mapper.Map<HoaDonDTO, SaveHoaDonDTO>(HoaDonDTO);

            sv = new ServeVM
            {
                BanAn = baDTO,
                HoaDon = saveHoaDonDTO,
                LoaiMonAns = _services.GetListLoaiMonAn(),
                ThucDons = _services.GetListMonAn(IdLoaiMonAn, pageIndex),
                ChiTietHoaDons = list,

            };

            return PartialView("_BanAnPartialView/_ListMonAnPartial", sv);
        }

        public IActionResult ThemCTHD(int IdHoaDon, int IdLoaiMonAn, int IdBanAn, int IdMonAn, int SoLuong, int pageIndex = 1)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            ServeVM sv = null;
            _services.ThemCTHD(IdHoaDon, IdMonAn, SoLuong);
            BanAnDTO baDTO = _services.GetBanAn(IdBanAn);
            HoaDonDTO HoaDon = _services.CapNhatThanhTien(IdHoaDon);
            SaveHoaDonDTO saveHoaDonDTO = _mapper.Map<HoaDonDTO, SaveHoaDonDTO>(HoaDon);

            IEnumerable<CTHDMD> list = _services.GetListCTHDMD(HoaDon.Id);

            sv = new ServeVM
            {
                BanAn = baDTO,
                HoaDon = saveHoaDonDTO,
                LoaiMonAns = _services.GetListLoaiMonAn(),
                ThucDons = _services.GetListMonAn(IdLoaiMonAn, pageIndex),
                ChiTietHoaDons = list
            };
            return PartialView("_BanAnPartialView/_CTHDPartial", sv);
        }

        public int? CapNhatSoLuongCTHD(int IdHoaDon, int IdMonAn, int SoLuong)
        {
            if (KiemTraDangNhap() == true)
            {
                _services.ThemCTHD(IdHoaDon, IdMonAn, SoLuong);
                HoaDonDTO HoaDon = _services.CapNhatThanhTien(IdHoaDon);
                return HoaDon.ThanhTien;
            }

            return null;

        }

        public IActionResult XoaCTHD(int IdHoaDon, int IdLoaiMonAn, int IdBanAn, int IdMonAn, int pageIndex = 1)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
                
            ServeVM sv = null;
            _services.DeleteCTHD(IdHoaDon, IdMonAn);
            BanAnDTO baDTO = _services.GetBanAn(IdBanAn);
            HoaDonDTO HoaDon = _services.CapNhatThanhTien(IdHoaDon);
            SaveHoaDonDTO saveHoaDonDTO = _mapper.Map<HoaDonDTO, SaveHoaDonDTO>(HoaDon);
            IEnumerable<CTHDMD> list = _services.GetListCTHDMD(HoaDon.Id);

            sv = new ServeVM
            {
                BanAn = baDTO,
                HoaDon = saveHoaDonDTO,
                LoaiMonAns = _services.GetListLoaiMonAn(),
                ThucDons = _services.GetListMonAn(IdLoaiMonAn, pageIndex),
                ChiTietHoaDons = list
            };
            return PartialView("_BanAnPartialView/_CTHDPartial", sv);
        }
    }
}