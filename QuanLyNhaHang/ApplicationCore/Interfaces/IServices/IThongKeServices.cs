using System;
using System.Collections.Generic;
using ApplicationCore.ModelsContainData.Models;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IThongKeServices
    {
        IEnumerable<ThongKeSLMonAnMD> GetListMonAnBanDuoc(DateTime thoiGianTu, DateTime thoiGianDen);
        int GetThongKeTongDoanhThu(DateTime thoiGianTu, DateTime thoiGianDen);
        int GetThongKeTongPhieuDatBan(DateTime thoiGianTu, DateTime thoiGianDen);
        int GetThongKePhieuDatBanBiHuy(DateTime thoiGianTu, DateTime thoiGianDen);
        int GetThongKePhieuDatBanXuLyXong(DateTime thoiGianTu, DateTime thoiGianDen);
        int GetTongSoBanDuocPhucVu(DateTime thoiGianTu, DateTime thoiGianDen);
        int GetThongKePhieuDatBanChuaXuLy(DateTime thoiGianTu, DateTime thoiGianDen);
    }
}