﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System;
    using ApplicationCore.Interfaces;

    public  class SaveThucDonDTO {

        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display (Name = "Tên loại món ăn")]
        public int IdLoaiMonAn { get; set; }

        [Required (ErrorMessage = "Không được để trống")]
        [Display (Name = "Tên món ăn")]
        public string Ten { get; set; }

        [Display (Name = "Giá")]
        [Required (ErrorMessage = "Không được để trống")]
        [Range (0, 5000000, ErrorMessage = "Hãy nhập giá hợp lệ")]
        public int Gia { get; set; }

    }
}