using System.Collections.Generic;
using ApplicationCore.Entitites;
using QuanLyNhaHang.Services;

namespace QuanLyNhaHang.ViewModels
{
    public class PhieuDatBanVM
    {
        public PaginatedList<PhieuDatBan> PhieuDatBans{ get; set; }
        public IEnumerable<BanAn> BanAns{ get; set; }
        public PhieuDatBan PhieuDatBan{ get; set; }
    }
}