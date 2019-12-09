using System.Collections.Generic;
using ApplicationCore.ModelsContainData.Models;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IThongKeServices
    {
        IEnumerable<ThongKeSLMonAnMD> GetListMonAnBanDuoc();
        int GetThongKeTongDoanhThu();
        int GetThongKeTongPhieuDatBan();
        int GetThongKePhieuDatBanBiHuy();
        int GetThongKePhieuDatBanXuLyXong();
        int GetTongSoBanDuocPhucVu();
    }
}