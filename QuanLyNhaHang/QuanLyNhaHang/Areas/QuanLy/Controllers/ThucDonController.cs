// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Web;
// using Microsoft.AspNetCore.Mvc;

// namespace QLNH.Areas.QuanLy.Controllers
// {
//     public class ThucDonController : Controller
//     {
//         // GET: QuanLy/ThucDon
//         public ActionResult Index(string sort, int? page)
//         {
//             var list = from s in context.ThucDons select s;
//             if (string.IsNullOrEmpty(sort))
//                 sort = "loai_asc";
//             ViewBag.CurrentSort = sort;

//             ViewBag.LoaiSort = sort=="loai_desc" ? "loai_asc" : "loai_desc";
//             ViewBag.TenThucAnSort = sort == "tenthucan_desc" ? "tenthucan_asc" : "tenthucan_desc";
//             ViewBag.GiaSort = sort == "gia_desc" ? "gia_asc" : "gia_desc";
//             switch (sort)
//             {
//                 case "loai_desc": list = list.OrderByDescending(s=>s.LoaiMonAn.Ten);
//                     break;
//                 case "loai_asc":
//                     list = list.OrderBy(s => s.LoaiMonAn.Ten);
//                     break;
//                 case "tenthucan_desc":
//                     list = list.OrderByDescending(s => s.Ten);
//                     break;
//                 case "tenthucan_asc":
//                     list = list.OrderBy(s => s.Ten);
//                     break;
//                 case "gia_desc":
//                     list = list.OrderByDescending(s => s.Gia);
//                     break;
//                 case "gia_asc":
//                     list = list.OrderBy(s => s.Gia);
//                     break;
//                 default:
//                     list = list.OrderBy(s => s.LoaiMonAn.Ten);
//                     break;
//             }
//             int pageSize = 7;
//             int pageNumber = (page ?? 1);
//             return View(list.ToPagedList(pageNumber,pageSize));
//         }

//         public ActionResult Create()
//         {
//             return View();
//         }

//         [HttpPost]
//         public ActionResult Create(ThucDon td)
//         {
//             if(ModelState.IsValid)
//             {
//                 context.ThucDons.Add(td);
//                 context.SaveChanges();
//                 ViewBag.Message = "Thêm thành công";
           
//             }
//             return RedirectToAction("Index");
//         }

//         public ActionResult Edit(int? id)
//         {

//             if (id == null)
//                 return RedirectToAction("Index");
//             ThucDon td = context.ThucDons.Find(id);
//             if (td == null)
//                 return RedirectToAction("Index");
//             return View(td);
//         }

//         [HttpPost]
//         public ActionResult Edit(ThucDon td)
//         {
//             if (ModelState.IsValid)
//             {
//                 context.Entry(td).State = System.Data.Entity.EntityState.Modified;
//                 context.SaveChanges();
//             }
//             return RedirectToAction("Index");
//         }

//        /* public ActionResult Delete(int id)
//         {
//             if (id == null)
//                 return RedirectToAction("Index");
//             ThucDon td = context.ThucDons.Find(id);
//             if (td == null)
//                 return RedirectToAction("Index");
//             return View(td);
//         }*/
//         [HttpGet]
//         //[ActionName("Delete")]
//         public ActionResult Delete(int? id)
//         {
//             if (id == null)
//                 RedirectToAction("Index");
//             ThucDon td = context.ThucDons.Find(id);
//             if(td ==null)
//                 RedirectToAction("Index");
//             context.Entry(td).State = System.Data.Entity.EntityState.Deleted;
//             context.SaveChanges();
//             return RedirectToAction("Index");
//         }
//         public ActionResult Details(int? id)
//         {
//             if (id == null)
//                 return RedirectToAction("Index");
//             ThucDon td = context.ThucDons.Find(id);
//             if (td == null)
//                 return RedirectToAction("Index");
//             return View(td);
//         }
//     }
// }
