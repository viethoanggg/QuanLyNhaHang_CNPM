using System;
using System.Globalization;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Services.Interfaces;
using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Controllers
{
    public class LoaiMonAnController : Controller
    {
        private readonly ILoaiMonAnServices _services;
        private readonly ILoaiMonAnIndexVMServices _servicesIndexVm;
        public LoaiMonAnController(ILoaiMonAnServices services, ILoaiMonAnIndexVMServices servicesIndexVM)
        {
            this._services = services;
            this._servicesIndexVm = servicesIndexVM;
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

        public IActionResult Index(string currentSort, string currentFilter, string searchString, int pageIndex = 1)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");

            if (!String.IsNullOrEmpty(searchString))
            {
                pageIndex = 1;
            }
            else
                searchString = currentFilter;

            if (String.IsNullOrEmpty(currentSort))
                currentSort = "TEN_DESC";


            ViewBag.CurrentSortName = currentSort.Equals("TEN_DESC") ? "TEN_ASC" : "TEN_DESC";
            ViewBag.CurrentSort = currentSort;
            ViewBag.CurrentFilter = searchString;
            LoaiMonAnVM loaiMonAnVM = _servicesIndexVm.GetLoaiMonAnVM(currentSort, searchString, pageIndex);

            return View(loaiMonAnVM);
        }

        [HttpPost]
        public IActionResult Create(string TenLoaiMonAn)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");

            if (String.IsNullOrEmpty(TenLoaiMonAn))
                return RedirectToAction("Index");
            SaveLoaiMonAnDTO save = new SaveLoaiMonAnDTO { Ten = TenLoaiMonAn };
            _services.Create(save);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (id == null)
                return RedirectToAction("Index");
            SaveLoaiMonAnDTO loaiMonAnDTO = _services.GetSaveLoaiMonAnDTO(id.Value);
            return View(loaiMonAnDTO);
        }
        [HttpPost]
        public IActionResult Edit(SaveLoaiMonAnDTO saveLoaiMonAnDTO)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (!ModelState.IsValid)
                return View(saveLoaiMonAnDTO);
            _services.Edit(saveLoaiMonAnDTO);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (id == null)
                return RedirectToAction("Index");
            LoaiMonAnDTO loaiMonAnDTO = _services.GetLoaiMonAn(id.Value);
            return View(loaiMonAnDTO);
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
            if (i == -1)
            {
                ViewBag.MessageError = "Loại món ăn này đã có món ăn, không thể xóa";
                LoaiMonAnDTO loaiMonAnDTO = _services.GetLoaiMonAn(id.Value);
                return View(loaiMonAnDTO);
            }
            return RedirectToAction("Index");
        }
    }


}