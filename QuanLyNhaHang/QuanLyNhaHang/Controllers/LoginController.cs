using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.ModelsContainData.Models;
using Infrastructure.Persistence.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace QuanLyNhaHang.Controllers
{
    public class LoginController : Controller
    {
        private readonly QLNHContext _context;
        public LoginController(QLNHContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("CurrentUser"))==false)
            {
                return View("../HomeQuanLy/Index");
            }
            return View();
        }

        public string GetMd5Hash(MD5 md5, string input)
        {
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                s.Append(bytes[i].ToString("X2"));

            }
            return s.ToString();

        }

        public bool VerifyMd5Hash(MD5 md5, string input, string sqlString)
        {
            string md5Hash = GetMd5Hash(md5, input);
            if (md5Hash.Equals(sqlString))
                return true;
            return false;
        }

        [HttpPost]
        public IActionResult Index(Account user)
        {

            string userName = user.Username;
            NguoiDung nd = _context.NguoiDungs.Where(x => x.TenDangNhap == userName).FirstOrDefault();
            if (nd == null)
            {
                ViewBag.Message = "Không có người dùng này";
                return View("Index");
            }
            using (MD5 md5 = MD5.Create())
            {
                if (VerifyMd5Hash(md5, user.Password, nd.MatKhau))
                {
                    HttpContext.Session.SetString("CurrentUser", nd.TenDangNhap);
                    return View("../HomeQuanLy/Index");
                }
                else
                {
                    ViewBag.Message = "Sai mật khẩu";
                    return View();
                }
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("../Login/Index");
        }
    }
}