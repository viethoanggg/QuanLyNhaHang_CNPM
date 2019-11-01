using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApplicationCore.Entitites;
using Infrastructure.Persistence.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Services;

namespace QuanLyNhaHang.Controllers {
    public class ThucDonController : Controller {
        // GET: QuanLy/ThucDon
        private readonly QLNHContext context;
        private readonly int pageSize = 3;
       // public ThucDonVM thucDonVM;
        public ThucDonController (QLNHContext context) {
            this.context = context;
        }
        public ActionResult Index (string sort,string searchString,string currentFilter, int pageIndex = 1) {

            if (String.IsNullOrEmpty(HttpContext.Session.GetString("CurrentUser")))
            {
                return View("../Login/Index");
            }

            var list = from s in context.ThucDons join t in context.LoaiMonAns
            on s.IdLoaiMonAn equals t.Id
            select new ThucDonMD {
            Id = s.Id,
            TenLoaiMonAn = t.Ten,
            Ten = s.Ten,
            Gia = s.Gia
            };

            if(searchString !=null)
                pageIndex = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            if(!String.IsNullOrEmpty(searchString))
            {
                list = list.Where(s => s.Ten.Contains(searchString.ToLower()) || s.TenLoaiMonAn.Contains(searchString.ToLower()));
            }

            if (string.IsNullOrEmpty (sort))
                sort = "loai_asc";
            ViewBag.CurrentSort = sort;

            ViewBag.LoaiSort = sort == "loai_desc" ? "loai_asc" : "loai_desc";
            ViewBag.TenThucAnSort = sort == "tenthucan_desc" ? "tenthucan_asc" : "tenthucan_desc";
            ViewBag.GiaSort = sort == "gia_desc" ? "gia_asc" : "gia_desc";
            switch (sort) {
                case "loai_desc":
                    list = list.OrderByDescending (s => s.TenLoaiMonAn);
                    break;
                case "loai_asc":
                    list = list.OrderBy (s => s.TenLoaiMonAn);
                    break;
                case "tenthucan_desc":
                    list = list.OrderByDescending (s => s.Ten);
                    break;
                case "tenthucan_asc":
                    list = list.OrderBy (s => s.Ten);
                    break;
                case "gia_desc":
                    list = list.OrderByDescending (s => s.Gia);
                    break;
                case "gia_asc":
                    list = list.OrderBy (s => s.Gia);
                    break;
                default:
                    list = list.OrderBy (s => s.TenLoaiMonAn);
                    break;
            }
          //  thucDonVM = new ThucDonVM ();
          //  thucDonVM.ThucDons = PaginatedList<ThucDonMD>.Create (list.ToList (), pageIndex, pageSize);
            
            return View (PaginatedList<ThucDonMD>.Create(list.ToList(), pageIndex, pageSize));
        }

        public ActionResult Create () {
            ViewData["ListLoaiMonAn"] = context.LoaiMonAns;
            return View ();
        }

        [HttpPost]
        public ActionResult Create (ThucDon td) {
            if (ModelState.IsValid) {
                context.ThucDons.Add (td);
                context.SaveChanges ();
                ViewBag.MessageTC = "Thêm thành công";
          
            }
            return RedirectToAction ("Index");
        }

        public ActionResult Edit (int? id) {

            if (id == null)
                return RedirectToAction ("Index");
            ThucDon td = context.ThucDons.Find (id);
            if (td == null)
                return RedirectToAction ("Index");
            ViewData["ListLoaiMonAn"] = context.LoaiMonAns;
            return View (td);
        }

        [HttpPost]
        public ActionResult Edit (ThucDon td) {
            if (ModelState.IsValid) {
                context.Entry (td).State = EntityState.Modified;
                context.SaveChanges ();
            }
            return RedirectToAction ("Index");
        }

        public ActionResult Delete (int? id) {
            if (id == null)
                return RedirectToAction ("Index");
            ThucDon td = context.ThucDons.Find (id);
            if (td == null)
                return RedirectToAction ("Index");
            return View (td);
        }

        [HttpPost]
        [ActionName ("Delete")]
        public ActionResult Deleted (int? id) {
            if (id == null)
                RedirectToAction ("Index");
            ThucDon td = context.ThucDons.Find (id);
            if (td == null)
                RedirectToAction ("Index");
            context.Entry (td).State = EntityState.Deleted;
            context.SaveChanges ();
            return RedirectToAction ("Index");
        }
        public ActionResult Details (int? id) {
            if (id == null)
                return RedirectToAction ("Index");
            ThucDon td = context.ThucDons.Find (id);
            if (td == null)
                return RedirectToAction ("Index");
            var list = from m in context.LoaiMonAns
            where m.Id == td.IdLoaiMonAn
            select new ThucDonMD {
                Id = td.Id,
                TenLoaiMonAn = m.Ten,
                Ten = td.Ten,
                Gia = td.Gia
            };
            var monAn = list.Where (s => s.Id == td.Id).FirstOrDefault ();
            return View (monAn);
        }
    }
}