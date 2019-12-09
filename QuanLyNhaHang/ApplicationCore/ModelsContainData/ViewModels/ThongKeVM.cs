using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.Services;

namespace ApplicationCore.ModelsContainData.ViewModels
{
    public class ThongKeVM
    {
        public PaginatedList<ThongKeSLMonAnMD> ListMonAnBanDuoc { get; set; }
        public int TongDoanhThu { get; set; }
        public int TongSoBanAnDuocPhucVu { get; set; }
        public int TongSoPhieuDatBan { get; set; }
        public int TongPhieuDatBanBiHuy { get; set; }
        public int TongPhieuDatBanXuLyXong { get; set; }

    }
}