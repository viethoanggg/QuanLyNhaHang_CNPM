using System;
using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entitites;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.Services;

namespace ApplicationCore.ModelsContainData.ViewModels
{
    public class ServeVM
    {
        public SaveHoaDonDTO HoaDon { get; set; }
        public BanAnDTO BanAn { get; set; }
        public int IdPhieuDatBan { get; set; }
        public PaginatedList<ThucDonDTO> ThucDons { get; set; }
        public IEnumerable<LoaiMonAnDTO> LoaiMonAns { get; set; }
        public IEnumerable<CTHDMD> ChiTietHoaDons { get; set; }
    }
}