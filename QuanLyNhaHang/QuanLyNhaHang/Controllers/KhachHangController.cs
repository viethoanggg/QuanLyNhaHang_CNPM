using System;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Services.Interfaces;
using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly IKhachHangServices _services;
        private readonly IKhachHangIndexVMServices _servicesIndexVM;
        public KhachHangController(IKhachHangServices services, IKhachHangIndexVMServices servicesIndexVM)
        {
            this._services = services;
            this._servicesIndexVM = servicesIndexVM;
        }

        public bool KiemTraDangNhap()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("TenDangNhapCurrentUser")))
            {
                return false;
            }
            else
            {
                ViewBag.TenCurrentUser = HttpContext.Session.GetString("TenCurrentUser").ToString();
                ViewBag.IdCurrentUser = HttpContext.Session.GetString("IdCurrentUser").ToString();
                return true;
            }
        }
        public IActionResult Index(string Ten, string SDT, string DiaChi, string currentSort, string currentFilterTen, string currentFilterSDT, string currentFilterDiaChi, int pageIndex = 1)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");

            if (!String.IsNullOrEmpty(Ten) || !String.IsNullOrEmpty(SDT) || !String.IsNullOrEmpty(DiaChi))
                pageIndex = 1;
            if (String.IsNullOrEmpty(Ten))
                Ten = currentFilterTen;
            if (String.IsNullOrEmpty(SDT))
                SDT = currentFilterSDT;
            if (String.IsNullOrEmpty(DiaChi))
                DiaChi = currentFilterDiaChi;
            @ViewBag.CurrentFilterTen = Ten;
            @ViewBag.CurrentFilterSDT = SDT;
            @ViewBag.CurrentFilterDiaChi = DiaChi;
            if (String.IsNullOrEmpty(currentSort))
                currentSort = "Ten_DESC";
            @ViewBag.CurrentSortTen = currentSort.Equals("Ten_DESC") ? "Ten_ASC" : "Ten_DESC";
            @ViewBag.CurrentSortSDT = currentSort.Equals("SDT_DESC") ? "SDT_ASC" : "SDT_DESC";
            @ViewBag.CurrentSortDiaChi = currentSort.Equals("DiaChi_DESC") ? "DiaChi_ASC" : "DiaChi_DESC";

            @ViewBag.CurrentSort = currentSort;
            KhachHangVM khachHangVM = _servicesIndexVM.GetKhachHangVM(currentSort, Ten, SDT, DiaChi, pageIndex);
            return View(khachHangVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");

            return View();
        }

        [HttpPost]
        public IActionResult Create(SaveKhachHangDTO SaveKhachHangDTO)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (!ModelState.IsValid)
            {
                return View(SaveKhachHangDTO);
            }
            _services.Create(SaveKhachHangDTO);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            SaveKhachHangDTO saveKhachHangDTO = _services.GetSaveKhachHangDTO(id.Value);
            if (saveKhachHangDTO == null)
                return RedirectToAction("Index");
            return View(saveKhachHangDTO);
        }
        [HttpPost]
        public IActionResult Edit(SaveKhachHangDTO saveKhachHangDTO)
        {
            if (!ModelState.IsValid)
                return View(saveKhachHangDTO);
            _services.Edit(saveKhachHangDTO);
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            return View(_services.GetKhachHang(id.Value));
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            return View(_services.GetSaveKhachHangDTO(id.Value));
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Deleted(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            int i = _services.Delete(id.Value);
            if (i.Equals(-1))
            {
                ViewBag.MessageDeleteError = "Danh sách phiếu đặt bàn của khách hàng bị null";
                return View(_services.GetSaveKhachHangDTO(id.Value));
            }
            else if (i.Equals(0))
            {
                ViewBag.MessageDeleteError = "Khách hàng này đã có phiếu đặt bàn, không thể xóa";
                return View(_services.GetSaveKhachHangDTO(id.Value));
            }
            return RedirectToAction("Index");
        }
    }
}