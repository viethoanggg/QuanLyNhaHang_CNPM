using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entities;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.Services;

namespace ApplicationCore.ModelsContainData.ViewModels
{
    public class PhieuDatBanVM
    {
        public PaginatedList<PhieuDatBanMD> PhieuDatBans{ get; set; }
        public IEnumerable<BanAnDTO> BanAns{ get; set; }
        public SavePhieuDatBanDTO PhieuDatBan{ get; set; }
        public IEnumerable<KhachHang> KhachHangs{ get; set; }
    }
}