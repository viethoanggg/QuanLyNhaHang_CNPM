using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Models;

namespace QuanLyNhaHang.Data
{
    public class SeedData
    {
        public static void Initialize(QLNHContext context)
        {

            context.Database.EnsureCreated();
            if (!context.NguoiDungs.Any())
            {
                string mk = "admin";
                using (MD5 md5 = MD5.Create())
                {
                    mk = GetMd5Hash(md5, mk);
                }
                context.NguoiDungs.AddRange(
                    new NguoiDung
                    {
                        Ten = "Admin",
                        TenDangNhap = "admin",
                        MatKhau = mk
                    });

                context.SaveChanges();
            }
        }

        private static string GetMd5Hash(MD5 md5, string input)
        {
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                s.Append(bytes[i].ToString("X2"));

            }
            return s.ToString();

        }
    }


}
