 using System.Collections.Generic;
 using System.Linq;
 using System.Web;
 using System;
 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace QLNH.Controllers 
{

     public class HomeQuanLyController : Controller {
         // GET: QuanLy/HomeQuanLy
         public HomeQuanLyController(){
             
         }
         public ActionResult Index () {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("CurrentUser")))
            {
                return View("../Login/Index");
            }
             return View ();
         }
     }
 }