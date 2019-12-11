using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;

namespace QuanLyNhaHang.ViewModels
{
    public class UserProfileVM
    {
        public NguoiDungDTO NguoiDungDTO { get; set; }
        public IEnumerable<HoaDon> ListHD { get; set; }
    }
}