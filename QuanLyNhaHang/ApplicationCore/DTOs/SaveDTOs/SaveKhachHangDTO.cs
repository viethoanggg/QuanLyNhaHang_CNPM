//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplicationCore.DTOs.SaveDTOs {
    using System.Collections.Generic;
    using System;
    using ApplicationCore.Interfaces;
    using System.ComponentModel.DataAnnotations;

    public class SaveKhachHangDTO  {

        public int Id { get; set; }
        
        [Display(Name = "Tên khách hàng")]
        [Required]
        public string Ten { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required]
        public string SDT { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required]
        public string DiaChi { get; set; }
        // public DiaChiNha DiaChi { get; set; }

        // public class DiaChiNha
        // {
        //     public string SoNha{ get; set; }
        //     public string TenDuong{ get; set; }
        //     public string Phuong{ get; set; }
        //     public string Quan{ get; set; }
        //     public string ThanhPho { get; set; }

        //     public string GetDiaChi()
        //     {
        //         string s = this.SoNha + "," + this.TenDuong + "," + this.Phuong + "," + this.Quan + "," + this.ThanhPho;
        //         return s.ToString();
        //     }
        //     public DiaChiNha(string SoNha,string TenDuong,string Phuong,string Quan,string ThanhPho)
        //     {
        //         this.SoNha = SoNha;
        //         this.TenDuong = TenDuong;
        //         this.Phuong = Phuong;
        //         this.Quan = Quan;
        //         this.ThanhPho = ThanhPho;
        //     }
    }

}