﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplicationCore.Entitites 
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;
    public partial class LoaiMonAn {
     
        public int Id { get; set; }

        [Display (Name = "Tên loại món ăn")]
        public string Ten { get; set; }

    }
}