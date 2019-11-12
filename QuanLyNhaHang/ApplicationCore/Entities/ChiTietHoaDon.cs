using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public partial class ChiTietHoaDon
    {
        public int IdHoaDon { get; set; }
        public int IdMonAn { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }

        ////////////////////////////////////////
        public virtual HoaDon HoaDon { get; set; }
        public virtual ThucDon ThucDon { get; set; }
    }
}