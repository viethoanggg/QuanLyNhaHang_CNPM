﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplicationCore.Entities 
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;
    using ApplicationCore.Interfaces;

    public  class LoaiMonAn : IAggregateRoot {

        public LoaiMonAn()
        {
            this.ThucDons = new HashSet<ThucDon>();
        }
        public int Id { get; set; }
        public string Ten { get; set; }

        //////////////////////////////////////////
        public virtual ICollection<ThucDon> ThucDons { get; set; }

    }
}