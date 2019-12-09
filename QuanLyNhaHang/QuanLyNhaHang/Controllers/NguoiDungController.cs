using System;
using ApplicationCore.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.ModelsContainData.ViewModels;
using QuanLyNhaHang.Services.Interfaces;
using ApplicationCore.DTOs.SaveDTOs;

namespace QuanLyNhaHang.Controllers
{
    public class NguoiDungController : Controller
    {
        private readonly INguoiDungServices _services;
        private readonly INguoiDungIndexVMServices _servicesIndexVM;
        public NguoiDungController(INguoiDungServices services, INguoiDungIndexVMServices servicesIndexVM)
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

        public IActionResult Index(string Ten, string TenDangNhap, string VaiTro, int TrangThai, string currentSort, string currentFilterTen, string currentFilterTenDangNhap, string currentFilterVaiTro, string currentFilterTrangThai, int pageIndex = 1)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");

            if (!String.IsNullOrEmpty(Ten) || !String.IsNullOrEmpty(TenDangNhap) || !String.IsNullOrEmpty(VaiTro) || !TrangThai.Equals(0))
                pageIndex = 1;
            if (String.IsNullOrEmpty(Ten))
                Ten = currentFilterTen;
            if (String.IsNullOrEmpty(TenDangNhap))
                TenDangNhap = currentFilterTenDangNhap;
            if (String.IsNullOrEmpty(VaiTro))
                VaiTro = currentFilterVaiTro;
            if (TrangThai.Equals(0) && !String.IsNullOrEmpty(currentFilterTrangThai))
                TrangThai = Convert.ToInt32(currentFilterTrangThai);
            @ViewBag.CurrentFilterTen = Ten;
            @ViewBag.CurrentFilterTenDangNhap = TenDangNhap;
            @ViewBag.CurrentFilterVaiTro = VaiTro;
            @ViewBag.CurrentFilterTrangThai = TrangThai;
            if (String.IsNullOrEmpty(currentSort))
                currentSort = "Ten_DESC";

            @ViewBag.CurrentSortTen = currentSort.Equals("Ten_DESC") ? "Ten_ASC" : "Ten_DESC";
            @ViewBag.CurrentSortTenDangNhap = currentSort.Equals("TenDangNhap_DESC") ? "TenDangNhap_ASC" : "TenDangNhap_DESC";
            @ViewBag.CurrentSortVaiTro = currentSort.Equals("VaiTro_DESC") ? "VaiTro_ASC" : "VaiTro_DESC";
            @ViewBag.CurrentSortTrangThai = currentSort.Equals("TrangThai_DESC") ? "TrangThai_ASC" : "TrangThai_DESC";

            @ViewBag.CurrentSort = currentSort;
            NguoiDungVM nguoiDungVM = _servicesIndexVM.GetNguoiDungVM(currentSort, Ten, TenDangNhap, VaiTro, TrangThai, pageIndex);
            return View(nguoiDungVM);
        }
[HttpGet]
        public IActionResult Create()
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");

            return View();
        }

        [HttpPost]
        public IActionResult Create(SaveNguoiDungDTO SaveNguoiDungDTO)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (!ModelState.IsValid)
            {
                return View(SaveNguoiDungDTO);
            }
            _services.Create(SaveNguoiDungDTO);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            SaveNguoiDungDTO saveNguoiDungDTO = _services.GetSaveNguoiDungDTO(id.Value);
            if (saveNguoiDungDTO == null)
                return RedirectToAction("Index");
            return View(saveNguoiDungDTO);
        }
        [HttpPost]
        public IActionResult Edit(SaveNguoiDungDTO saveNguoiDungDTO)
        {
            if (!ModelState.IsValid)
                return View(saveNguoiDungDTO);
            _services.Edit(saveNguoiDungDTO);
            return RedirectToAction("Index");
        }
    }
}