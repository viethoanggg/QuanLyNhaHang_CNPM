 using System.Collections.Generic;
 using System.Linq;
 using System.Web;
 using System;
 using Microsoft.AspNetCore.Http;
 using Microsoft.AspNetCore.Mvc;

 namespace QLNH.Controllers {

     public class HomeQuanLyController : Controller {
         // GET: QuanLy/HomeQuanLy
         public HomeQuanLyController () {

         }
         public IActionResult Index () {
             if (KiemTraDangNhap () == false)
                 return View ("../Login/Index");
             return View ();
         }
         public bool KiemTraDangNhap () {
             if (String.IsNullOrEmpty (HttpContext.Session.GetString ("TenDangNhapCurrentUser"))) {
                 return false;
             } else {
                 ViewBag.TenCurrentUser = HttpContext.Session.GetString ("TenCurrentUser").ToString ();
                 ViewBag.IdCurrentUser = HttpContext.Session.GetString ("IdCurrentUser").ToString ();
                 return true;
             }
         }
     }
 }