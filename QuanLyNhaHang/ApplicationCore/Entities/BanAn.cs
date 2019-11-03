using System.ComponentModel.DataAnnotations.Schema;
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplicationCore.Entitites {
    using System.Collections.Generic;
    using System;
    using ApplicationCore.Interfaces;
    using System.ComponentModel.DataAnnotations;

    public class BanAn :IAggregateRoot {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Bàn số ")]
        public int Id { get; set; }

        [Required]
        [Display(Name="Loại bàn ăn")]
        public string LoaiBanAn { get; set; }

        [Required]
        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; }

        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

    }
}