//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplicationCore.Entities {
    using System.Collections.Generic;
    using System;
    using ApplicationCore.Interfaces;

    public class NguoiDung : IAggregateRoot {

        public NguoiDung()
        {
            this.HoaDons = new HashSet<HoaDon>();
        }
        public int Id { get; set; }
        public string Ten { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Role { get; set; }

        ///////////////////////////////////////////
        public virtual ICollection<HoaDon> HoaDons { get; set; }

    }
}