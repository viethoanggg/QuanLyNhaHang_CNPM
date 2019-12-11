//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplicationCore.DTOs.SaveDTOs
{
    using System.Collections.Generic;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ApplicationCore.Entities;

    public class SaveChiTietHoaDonDTO {

       
        [Display(Name = "Mã hóa đơn")]
        [Key, Column(Order = 0)]
        [ForeignKey("HoaDon")]
        public int IdHoaDon { get; set; }

        [Display(Name = "Món ăn")]
        [ForeignKey("ThucDon")]
        [Key, Column(Order = 1)]
        public int IdMonAn { get; set; }

        [Range(1,10)]
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }

        [Range(1, 5000000)]
        [Display(Name = "Đơn giá")]
        public int DonGia { get; set; }

        public virtual HoaDon HoaDon { get; set; }
        public virtual ThucDon ThucDon { get; set; }

    }
}