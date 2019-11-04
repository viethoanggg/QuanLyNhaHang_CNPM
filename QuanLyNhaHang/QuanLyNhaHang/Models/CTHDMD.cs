
namespace QuanLyNhaHang.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System;
    public class CTHDMD
    {

        public int IdHoaDon { get; set; }
        public int IdMonAn { get; set; }

        [Display(Name = "Tên món ăn")]
        public string TenMonAn { get; set; }

        [Display(Name = "Số lượng")]
        [Range(0, 50)]
        public int SoLuong { get; set; }

        [Display(Name = "Đơn giá")]
        public int DonGia { get; set; }

    }
}