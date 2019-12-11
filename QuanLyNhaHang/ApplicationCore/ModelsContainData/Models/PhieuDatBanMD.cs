using System;

namespace ApplicationCore.ModelsContainData.Models
{
    public class PhieuDatBanMD
    {
        public int Id { get; set; }
        public int IdBanAn { get; set; }
        public int IdKhachHang { get; set; }
        public string TenKhachHang{ get; set; }
        public int IdUser { get; set; }
        public string TenUser { get; set; }
        public DateTime ThoiGianDat { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
    }
}