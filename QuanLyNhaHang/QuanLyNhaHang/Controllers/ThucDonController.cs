using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Web;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.ModelsContainData.ViewModels;
using AutoMapper;
using Infrastructure.Persistence.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Services.Interfaces;

namespace QuanLyNhaHang.Controllers
{
    public class ThucDonController : Controller
    {
        // GET: QuanLy/ThucDon
        private readonly IThucDonServices _services;
        private readonly IThucDonIndexVMServices _servicesIndexVM;
        private readonly IMapper _mapper;

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
        public ThucDonController(IThucDonServices services, IThucDonIndexVMServices servicesIndexVM, IMapper mapper)
        {
            _services = services;
            _servicesIndexVM = servicesIndexVM;
            _mapper = mapper;
        }
        public ActionResult Index(string searchString, string searchStringGiaTu, string searchStringGiaDen, string currentSort, string currentFilter, int pageIndex = 1)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");

            if (String.IsNullOrEmpty(currentSort))
                currentSort = "TenMonAn_DESC";

            if (!String.IsNullOrEmpty(searchString))
            {
                pageIndex = 1;
            }
            else
                searchString = currentFilter;

            ViewBag.CurrentSortTenMonAn = currentSort.Equals("TenMonAn_DESC") ? "TenMonAn_ASC" : "TenMonAn_DESC";
            ViewBag.CurrentSortTenLoaiMonAn = currentSort.Equals("TenLoaiMonAn_DESC") ? "TenLoaiMonAn_ASC" : "TenLoaiMonAn_DESC";
            ViewBag.CurrentSortGia = currentSort.Equals("Gia_DESC") ? "Gia_ASC" : "Gia_DESC";
            ViewBag.CurrentSort = currentSort;
            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentFilterGiaTu = searchStringGiaTu;
            ViewBag.CurrentFilterGiaDen = searchStringGiaDen;
            ThucDonVM vm = _servicesIndexVM.GetThucDonVM(searchString, searchStringGiaTu, searchStringGiaDen, currentSort, pageIndex);
            return View(vm);
        }
        public ActionResult Create()
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            ViewData["ListLoaiMonAn"] = _services.GetLoaiMonAns();
            return View();
        }

        [HttpPost]
        public ActionResult Create(SaveThucDonDTO saveThucDonDTO)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (!ModelState.IsValid)
            {
                ViewData["ListLoaiMonAn"] = _services.GetLoaiMonAns();
                return View(saveThucDonDTO);
            }
            else
            {
                _services.Create(saveThucDonDTO);
            }
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int? id)
        {

            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            // if (id == null)
            //     return RedirectToAction ("Index");
            // ThucDon td = context.ThucDons.Find (id);
            // if (td == null)
            //     return RedirectToAction ("Index");
            // ViewData["ListLoaiMonAn"] = context.LoaiMonAns;
            // return View (td);
            if (id == null)
                return RedirectToAction("Index");
            ThucDonDTO tdDTO = _services.GetMonAn(id.Value);
            if (tdDTO == null)
                return RedirectToAction("Index");
            ViewData["ListLoaiMonAn"] = _services.GetLoaiMonAns();
            SaveThucDonDTO saveThucDonDTO = _mapper.Map<ThucDonDTO, SaveThucDonDTO>(tdDTO);
            return View(saveThucDonDTO);
        }

        [HttpPost]
        public ActionResult Edit(SaveThucDonDTO saveThucDonDTO)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            // if (ModelState.IsValid) {
            //     context.Entry (td).State = EntityState.Modified;
            //     context.SaveChanges ();
            // }
            if (ModelState.IsValid)
            {
                _services.Edit(saveThucDonDTO);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            // if (id == null)
            //     return RedirectToAction ("Index");
            // ThucDon td = context.ThucDons.Find (id);
            // if (td == null)
            //     return RedirectToAction ("Index");
            // return View (td);
            if (id == null)
                return RedirectToAction("Index");
            ThucDonDTO tdDTO = _services.GetMonAn(id.Value);
            if (tdDTO == null)
                return RedirectToAction("Index");
            SaveThucDonDTO saveThucDonDTO = _mapper.Map<ThucDonDTO, SaveThucDonDTO>(tdDTO);
            return View(saveThucDonDTO);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Deleted(int? id)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            // if (id == null)
            //     RedirectToAction ("Index");
            // ThucDon td = context.ThucDons.Find (id);
            // if (td == null)
            //     RedirectToAction ("Index");
            // context.Entry (td).State = EntityState.Deleted;
            // context.SaveChanges ();
            if (id == null)
                return RedirectToAction("Index");
            // SaveThucDonDTO saveThucDonDTO = _mapper.Map<ThucDonDTO, SaveThucDonDTO>(tdDTO);
            _services.Remove(id.Value);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            // if (id == null)
            //     return RedirectToAction ("Index");
            // ThucDon td = context.ThucDons.Find (id);
            // if (td == null)
            //     return RedirectToAction ("Index");
            // var list = from m in context.LoaiMonAns
            // where m.Id == td.IdLoaiMonAn
            // select new ThucDonMD {
            //     Id = td.Id,
            //     TenLoaiMonAn = m.Ten,
            //     Ten = td.Ten,
            //     Gia = td.Gia
            // };
            // var monAn = list.Where (s => s.Id == td.Id).FirstOrDefault ();
            // return View (monAn);
            if (id == null)
                return RedirectToAction("Index");
            ThucDonMD tdMD = _services.GetMonAnMD(id.Value);
            if (tdMD == null)
                return RedirectToAction("Index");

            return View(tdMD);
        }
    }
}