using System;
using System.Reflection.Metadata;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyNhaHang.Controllers
{
    public class HoaDonController : Controller
    {
        private readonly IHoaDonServices _services;
        private readonly IMapper _mapper;
        public HoaDonController(IHoaDonServices services, IMapper mapper)
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
            return View(_services.GetHoaDonVM(pageIndex));
        }
        public IActionResult Delete(int? id)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (id == null)
                return RedirectToAction("Index");
            HoaDonDTO hoaDonDTO = _services.FindHD(id.Value);
            if (hoaDonDTO == null)
                return RedirectToAction("Index");
            ViewBag.UserName = _services.GetNameUser(hoaDonDTO.IdUser);
            SaveHoaDonDTO saveHoaDonDTO = _mapper.Map<HoaDonDTO, SaveHoaDonDTO>(hoaDonDTO);
            return View(saveHoaDonDTO);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Deleted(int? id)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (id == null)
                return RedirectToAction("Index");
                
            int i= _services.Delete(id.Value);
            if(i==0)
            {
                ViewBag.Error = "Hóa đơn này đang tính cho bàn ăn đang được phục vụ ,không thể xóa ";
                HoaDonDTO hoaDonDTO= _services.FindHD(id.Value);
                SaveHoaDonDTO saveHoaDonDTO = _mapper.Map<HoaDonDTO, SaveHoaDonDTO>(hoaDonDTO);
                ViewBag.UserName = _services.GetNameUser(hoaDonDTO.IdUser);
                return View(saveHoaDonDTO);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (id == null)
                return RedirectToAction("Index");
            HoaDonDTO hoaDonDTO = _services.FindHD(id.Value);
            if (hoaDonDTO == null)
                return RedirectToAction("Index");
            ViewBag.UserName = _services.GetNameUser(hoaDonDTO.IdUser);
            return View(_services.Details(id.Value));
        }
        public IActionResult Edit(int? id)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (id == null)
                return RedirectToAction("Index");
            ViewData["ListBanAn"] = _services.GetListBanAn();
            SaveHoaDonDTO saveHoaDonDTO = _mapper.Map<HoaDonDTO, SaveHoaDonDTO>(_services.FindHD(id.Value));
            ViewBag.UserName = _services.GetNameUser(saveHoaDonDTO.IdUser);
            return View(saveHoaDonDTO);
        }

        [HttpPost]
        public IActionResult Edit(SaveHoaDonDTO SaveHoaDonDTO)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (!ModelState.IsValid)
            {
                ViewData["ListBanAn"] = _services.GetListBanAn();
                ViewBag.UserName = _services.GetNameUser(SaveHoaDonDTO.IdUser);
                return View(SaveHoaDonDTO);
            }
            _services.Edit(SaveHoaDonDTO);
            return RedirectToAction("Index");
        }
    }
}