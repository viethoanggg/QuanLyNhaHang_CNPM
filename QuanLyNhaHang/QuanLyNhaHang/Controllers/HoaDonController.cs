using System;
using System.Reflection.Metadata;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Services.Interfaces;

namespace QuanLyNhaHang.Controllers
{
    public class HoaDonController : Controller
    {
        private readonly IHoaDonServices _services;
        private readonly IHoaDonIndexVMServices _servicesIndexVM;
        private readonly IMapper _mapper;
        public HoaDonController(IHoaDonServices services, IHoaDonIndexVMServices servicesIndexVM, IMapper mapper)
        {
            this._services = services;
            this._servicesIndexVM = servicesIndexVM;
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
        public IActionResult Index(int idBanAn, string trangThai, string currentSort, string currentFilterIdBanAn, string currentFilterTrangThai, int pageIndex = 1)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (String.IsNullOrEmpty(idBanAn.ToString()))
                idBanAn = 0;
            if (!idBanAn.Equals(0))
            {
                pageIndex = 1;
            }
            else if (!String.IsNullOrEmpty(currentFilterIdBanAn))
            {
                idBanAn = Convert.ToInt32(currentFilterIdBanAn.ToString());
            }
            
            if (!String.IsNullOrEmpty(trangThai))
            {
                pageIndex = 1;
            }
            else
            {
                trangThai = currentFilterTrangThai;
            }
            ViewBag.CurrentFilterTrangThai = trangThai;
            ViewBag.CurrentFilterIdBanAn = idBanAn;
           
            if (String.IsNullOrEmpty(currentSort))
                currentSort = "BanAn_DESC";

            ViewBag.CurrentSortIdBanAn = currentSort.Equals("BanAn_DESC") ? "BanAn_ASC" : "BanAn_DESC";
            ViewBag.CurrentSortTrangThai = currentSort.Equals("TrangThai_DESC") ? "TrangThai_ASC" : "TrangThai_DESC";
            ViewBag.CurrentSortThoiGianLap = currentSort.Equals("ThoiGianLap_DESC") ? "ThoiGianLap_ASC" : "ThoiGianLap_DESC";
            ViewBag.CurrentSortThoiGianThanhToan = currentSort.Equals("ThoiGianThanhToan_DESC") ? "ThoiGianThanhToan_ASC" : "ThoiGianThanhToan_DESC";
            ViewBag.CurrentSortTenNhanVien = currentSort.Equals("TenNhanVien_DESC") ? "TenNhanVien_ASC" : "TenNhanVien_DESC";
            ViewBag.CurrentSortThanhTien = currentSort.Equals("ThanhTien_DESC") ? "ThanhTien_ASC" : "ThanhTien_DESC";
            ViewBag.CurrentSortIdHoaDon = currentSort.Equals("IdHoaDon_DESC") ? "IdHoaDon_ASC" : "IdHoaDon_DESC";

            ViewBag.CurrentSort = currentSort;
            return View(_servicesIndexVM.GetHoaDonVM(currentSort, idBanAn, trangThai, pageIndex));
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

            int i = _services.Delete(id.Value);
            if (i == 0)
            {
                ViewBag.Error = "Hóa đơn này đang tính cho bàn ăn đang được phục vụ ,không thể xóa ";
                HoaDonDTO hoaDonDTO = _services.FindHD(id.Value);
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
            return View(_servicesIndexVM.Details(id.Value));
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