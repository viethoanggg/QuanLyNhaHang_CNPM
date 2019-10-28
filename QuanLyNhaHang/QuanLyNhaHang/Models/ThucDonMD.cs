
namespace QuanLyNhaHang.Models
 {
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System;
    public partial class ThucDonMD {

        public int Id { get; set; }

        [Display (Name = "Tên loại món ăn")]
        public string TenLoaiMonAn { get; set; }

        [Display (Name = "Tên món ăn")]
        public string Ten { get; set; }

        [Display (Name = "Giá")]
        public int Gia { get; set; }

    }
}