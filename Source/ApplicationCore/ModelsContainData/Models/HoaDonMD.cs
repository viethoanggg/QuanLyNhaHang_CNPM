using System;

namespace ApplicationCore.ModelsContainData.Models {
    public class HoaDonMD {
        public int Id { get; set; }

        public int IdBanAn { get; set; }

        public int IdUser { get; set; }

        public string TenNhanVien { get; set; }

        public System.DateTime ThoiGianLap { get; set; }

        public Nullable<System.DateTime> ThoiGianThanhToan { get; set; }

        public int ThanhTien { get; set; }

        public string TrangThai { get; set; }
    }
}