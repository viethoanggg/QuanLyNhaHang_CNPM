using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IServices;
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
        private readonly INguoiDungServices _services;
        public LoginController(INguoiDungServices services)
        {
            this._services = services;

        }
        public IActionResult Index()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("TenDangNhapCurrentUser")) == false)
            {
                ViewBag.IdCurrentUser = HttpContext.Session.GetString("IdCurrentUser").ToString();
                ViewBag.TenCurrentUser = HttpContext.Session.GetString("TenCurrentUser").ToString();
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
            NguoiDungDTO nd = _services.GetNguoiDungDTOByUserName(userName);
            if (nd == null)
            {
                ViewBag.Message = "Không có người dùng này";
                return View("Index");
            }
            using (MD5 md5 = MD5.Create())
            {
                if (VerifyMd5Hash(md5, user.Password, nd.MatKhau))
                {
                    if (nd.TrangThai.Equals(-1))
                    {
                        ViewBag.Message = "Tài khoản này đã bị khóa";
                        return View("Index");
                    }
                    HttpContext.Session.SetString("TenDangNhapCurrentUser", nd.TenDangNhap);
                    HttpContext.Session.SetString("IdCurrentUser", nd.Id.ToString());
                    HttpContext.Session.SetString("TenCurrentUser", nd.Ten);
                    HttpContext.Session.SetString("TrangThaiCurrentUser", nd.TrangThai.ToString());
                    HttpContext.Session.SetString("VaiTroCurrentUser", nd.Role);
                    HttpContext.Session.SetString("MatKhauCurrentUser", nd.MatKhau);

                    ViewBag.IdCurrentUser = HttpContext.Session.GetString("IdCurrentUser").ToString();
                    ViewBag.TenCurrentUser = HttpContext.Session.GetString("TenCurrentUser").ToString();
                    ViewBag.Time = DateTime.Now;
                    return View("../HomeQuanLy/Index",nd);
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
            HttpContext.Session.Remove("TenDangNhapCurrentUser");
            HttpContext.Session.Clear();
            return View("../Login/Index");
        }
    }
}