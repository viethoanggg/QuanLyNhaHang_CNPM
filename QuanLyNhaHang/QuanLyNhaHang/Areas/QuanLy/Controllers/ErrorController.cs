using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace QLNH.Areas.QuanLy.Controllers
{
    public class ErrorController : Controller
    {
        // GET: QuanLy/Error
        public ActionResult Index()
        {
            return View();
        }
    }
}