using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Services;

namespace ApplicationCore.ModelsContainData.ViewModels
{
    public class PhieuDatBanVM
    {
        public PaginatedList<PhieuDatBanDTO> PhieuDatBans{ get; set; }
        public IEnumerable<BanAnDTO> BanAns{ get; set; }
        public SavePhieuDatBanDTO PhieuDatBan{ get; set; }
    }
}