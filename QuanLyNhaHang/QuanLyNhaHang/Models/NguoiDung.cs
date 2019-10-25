using System.ComponentModel.DataAnnotations;

namespace QuanLyNhaHang.Models
{
    public class NguoiDung
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tên")]
        public string Ten { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
    }
}