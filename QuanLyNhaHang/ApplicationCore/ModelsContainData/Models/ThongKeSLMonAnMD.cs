using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.ModelsContainData.Models
{
    public class ThongKeSLMonAnMD
    {
        public int Id { get; set; }

        [Display(Name = "Tên loại món ăn")]
        public string TenLoaiMonAn { get; set; }

        [Display(Name = "Tên món ăn")]
        public string Ten { get; set; }

        [Display(Name = "Giá")]
        public int Gia { get; set; }

        [Display(Name = "Số lượng bán được")]
        public int SoLuongBanDuoc { get; set; }
    }
}