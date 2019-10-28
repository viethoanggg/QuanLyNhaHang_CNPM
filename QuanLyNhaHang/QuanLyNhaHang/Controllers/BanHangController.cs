// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Web;
// using Microsoft.AspNetCore.Mvc;

// namespace QLNH.Areas.QuanLy.Controllers
// {
//     public class BanHangController : Controller
//     {
//         // GET: QuanLy/BanHang
//         public ActionResult Index()
//         {
            
            
//             return View();
//         }
//         [HttpPost]
//         public JsonResult ListThucDon(int? idLoai)
//         {
//             db.Configuration.ProxyCreationEnabled = false;
//             if (idLoai == null)
//                 idLoai = 1;
//             var list = from a in db.ThucDons.Where(s=>s.IdLoaiMonAn==idLoai) select a ;
//             list = list.OrderBy(s => s.LoaiMonAn.Ten);
//             return Json(new { listTD=list, JsonRequestBehavior.AllowGet });
//         }

//     }
// }