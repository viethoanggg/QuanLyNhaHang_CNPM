//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplicationCore.DTOs
{
    using System.Collections.Generic;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class NguoiDungDTO {
   
        public int Id { get; set; }

        [Display(Name="Tên")]
        [Required]
        public string Ten { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required]
        public string TenDangNhap { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required]
        public string MatKhau { get; set; }

        [Display(Name = "Vai trò")]
        [Required]
        public string Role { get; set; }

    }
}