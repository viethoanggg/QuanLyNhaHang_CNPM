using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;

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
        public IActionResult HashStringInput([Bind("Username", "Password")] Account user)
        {

            string userName = user.Username;
            NguoiDung nd = _context.NguoiDungs.Where(x => x.TenDangNhap == userName).FirstOrDefault();
            if (nd == null)
            {
                return RedirectToAction("Index");
            }
            using (MD5 md5 = MD5.Create())
            {
                if (VerifyMd5Hash(md5, user.Password, nd.MatKhau))
                {
                    return View("../Home/Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}