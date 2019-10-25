// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Web;
// using Microsoft.AspNetCore.Mvc;

// namespace QLNH.Areas.QuanLy.Controllers
// {
//     public class HomeQuanLyController : Controller
//     {
//         // GET: QuanLy/HomeQuanLy
//         public ActionResult Index()
//         {
//             if (CurrentUser.StatusCurrentUser.Equals("1"))
//                 return View();
//             else
//                 return RedirectToAction("../../Login");
//         }
//     }
// }