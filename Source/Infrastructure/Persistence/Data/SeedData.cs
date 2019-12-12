using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ApplicationCore.Entities;

namespace Infrastructure.Persistence.Data
{
    public class SeedData
    {
        public static void Initialize(QLNHContext context)
        {

            context.Database.EnsureCreated();
            if (!context.NguoiDungs.Any())
            {
                string mk = "admin";
                string mkh = "123";
                string mkt = "123";
                string mktiep = "123";
                string mkNV = "123";
                using (MD5 md5 = MD5.Create())
                {
                    mk = GetMd5Hash(md5, mk);
                    mkh = GetMd5Hash(md5, mkh);
                    mkt = GetMd5Hash(md5, mkt);
                    mktiep = GetMd5Hash(md5, mktiep);
                    mkNV = GetMd5Hash(md5, mkNV);
                }
                context.NguoiDungs.AddRange(
                    new NguoiDung
                    {
                        Ten = "Admin",
                        TenDangNhap = "admin",
                        MatKhau = mk,
                        Role = "Quản lý",
                        TrangThai = 1
                    },
                    new NguoiDung
                    {
                        Ten = "Hoàng",
                        TenDangNhap = "hoang",
                        MatKhau = mkh,
                        Role = "Quản lý",
                        TrangThai = 1
                    },
                    new NguoiDung
                    {
                        Ten = "Triết",
                        TenDangNhap = "triet",
                        MatKhau = mkt,
                        Role = "Quản lý",
                        TrangThai = 1
                    },
                    new NguoiDung
                    {
                        Ten = "Tiếp",
                        TenDangNhap = "tiep",
                        MatKhau = mktiep,
                        Role = "Quản lý",
                        TrangThai = 1
                    },
                    new NguoiDung
                    {
                        Ten = "Nhân viên thu ngân",
                        TenDangNhap = "nhanvien",
                        MatKhau = mkNV,
                        Role = "Nhân viên",
                        TrangThai = 1
                    });
            }
            if (!context.BanAns.Any())
            {
                context.BanAns.AddRange(
                    new BanAn
                    {
                        Id = 1,
                        LoaiBanAn = "2 người",
                        TrangThai = "Trống",
                        GhiChu = ""
                    },
                    new BanAn
                    {
                        Id = 2,
                        LoaiBanAn = "2 người",
                        TrangThai = "Trống",
                        GhiChu = ""
                    },
                    new BanAn
                    {
                        Id = 3,
                        LoaiBanAn = "4 người",
                        TrangThai = "Trống",
                        GhiChu = ""
                    },
                    new BanAn
                    {
                        Id = 4,
                        LoaiBanAn = "4 người",
                        TrangThai = "Trống",
                        GhiChu = ""
                    },
                    new BanAn
                    {
                        Id = 5,
                        LoaiBanAn = "8 người",
                        TrangThai = "Trống",
                        GhiChu = ""
                    },
                    new BanAn
                    {
                        Id = 6,
                        LoaiBanAn = "8 người",
                        TrangThai = "Trống",
                        GhiChu = ""
                    },
                    new BanAn
                    {
                        Id = 7,
                        LoaiBanAn = "10 người",
                        TrangThai = "Trống",
                        GhiChu = ""
                    },
                    new BanAn
                    {
                        Id = 8,
                        LoaiBanAn = "10 người",
                        TrangThai = "Trống",
                        GhiChu = ""
                    },
                    new BanAn
                    {
                        Id = 9,
                        LoaiBanAn = "4 người",
                        TrangThai = "Trống",
                        GhiChu = ""
                    },
                    new BanAn
                    {
                        Id = 10,
                        LoaiBanAn = "4 người",
                        TrangThai = "Trống",
                        GhiChu = ""
                    }
                );
            }
            if (!context.LoaiMonAns.Any())
            {
                context.LoaiMonAns.AddRange(
                    new LoaiMonAn
                    {
                        Ten = "Hải sản"
                    },
                    new LoaiMonAn
                    {
                        Ten = "Mực"
                    },
                    new LoaiMonAn
                    {
                        Ten = "Cá hồi"
                    },
                    new LoaiMonAn
                    {
                        Ten = "Súp"
                    },
                    new LoaiMonAn
                    {
                        Ten = "Gỏi"
                    },
                    new LoaiMonAn
                    {
                        Ten = "Lẩu các loại"
                    },
                    new LoaiMonAn
                    {
                        Ten = "Món chiên"
                    },
                    new LoaiMonAn
                    {
                        Ten = "Thức uống"
                    }
                );
            }

            if (!context.ThucDons.Any())
            {
                context.ThucDons.AddRange(
                    new ThucDon
                    {
                        IdLoaiMonAn = 1,
                        Ten = "Gỏi sứa",
                        Gia = 60000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 1,
                        Ten = "Cua rang me",
                        Gia = 80000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 1,
                        Ten = "Cua hấp sả",
                        Gia = 200000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 1,
                        Ten = "Cua rang muối",
                        Gia = 250000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 1,
                        Ten = "Sò huyết nướng",
                        Gia = 250000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 2,
                        Ten = "Mực xào thập cẩm",
                        Gia = 280000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 2,
                        Ten = "Mực chiên bơ",
                        Gia = 280000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 2,
                        Ten = "Mực trứng hấp",
                        Gia = 180000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 2,
                        Ten = "Mực trứng nướng muối ớt",
                        Gia = 180000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 2,
                        Ten = "Mực trứng chiên",
                        Gia = 180000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 3,
                        Ten = "Súp cá hồi",
                        Gia = 20000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 3,
                        Ten = "Gỏi cá hồi",
                        Gia = 250000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 3,
                        Ten = "Cháo cá hồi",
                        Gia = 20000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 3,
                        Ten = "Cá hồi nướng",
                        Gia = 320000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 3,
                        Ten = "Cá hồi hấp xì dầu",
                        Gia = 350000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 3,
                        Ten = "Cá hồi rang muối ",
                        Gia = 320000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 4,
                        Ten = "Súp cua ",
                        Gia = 28000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 4,
                        Ten = "Súp bắp cua ",
                        Gia = 31000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 4,
                        Ten = "Súp tôm ",
                        Gia = 33000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 4,
                        Ten = "Súp nghêu ",
                        Gia = 28000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 4,
                        Ten = "Súp hải sản ",
                        Gia = 29000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 5,
                        Ten = "Gỏi bưởi ",
                        Gia = 121000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 5,
                        Ten = "Gỏi bò bóp thấu ",
                        Gia = 110000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 5,
                        Ten = "Gỏi ngó sen tôm thịt ",
                        Gia = 121000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 5,
                        Ten = "Gỏi khoai môn ",
                        Gia = 110000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 5,
                        Ten = "Gỏi xoài tôm thịt ",
                        Gia = 110000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 6,
                        Ten = "Lẩu vịt ",
                        Gia = 400000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 6,
                        Ten = "Lẩu cá lăng ",
                        Gia = 400000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 6,
                        Ten = "Lẩu riêu cua hấp bò",
                        Gia = 500000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 6,
                        Ten = "Lẩu bò nhúng giấm ",
                        Gia = 350000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 6,
                        Ten = "Lẩu thập cẩm ",
                        Gia = 600000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 6,
                        Ten = "Lẩu ếch măng cay ",
                        Gia = 400000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 6,
                        Ten = "Lẩu gà rượu vang ",
                        Gia = 600000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 7,
                        Ten = "Chả giò thăng hoa ",
                        Gia = 50000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 7,
                        Ten = "Khoai lang chiên",
                        Gia = 30000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 7,
                        Ten = "Cà tím chiên dòn ",
                        Gia = 40000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 7,
                        Ten = "Hoành thánh chiên tứ vị ",
                        Gia = 50000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 7,
                        Ten = "Nấm bào ngư chiên xù ",
                        Gia = 40000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 8,
                        Ten = "Nước ngọt các loại ",
                        Gia = 12000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 8,
                        Ten = "Nước suối ",
                        Gia = 7000
                    },
                    new ThucDon
                    {
                        IdLoaiMonAn = 8,
                        Ten = "Bia các loại ",
                        Gia = 15000
                    }
                );

                if (!context.KhachHangs.Any())
                {
                    context.AddRange(
                        new KhachHang
                        {
                            Ten = "Hoàng GG",
                            SDT = "0123456789",
                            DiaChi = "12/2,Quang Trung, Phường 7 ,Quận Gò Vấp,TPHCM"
                            // DiaChi=new KhachHang.DiaChiNha{
                            //     SoNha="12/34",
                            //     TenDuong="Tân Sơn",
                            //     Phuong="Phường 15",
                            //     Quan="Quận Tân Bình",
                            //     ThanhPho="TPHCM"
                            // }
                            // DiaChi= new KhachHang.DiaChiNha("12.34","Tân Sơn","Phường 15","Quận Tân Bình","TPHCM")
                        },
                        new KhachHang
                        {
                            Ten = "Minh",
                            SDT = "0123459829",
                            DiaChi = "12/2,Tân Sơn, Phường 15 ,Quận Tân Bình,TPHCM"
                            // DiaChi = new KhachHang.DiaChiNha
                            // {
                            //     SoNha = "91/2",
                            //     TenDuong = "Quang Trung",
                            //     Phuong = "Phường 1",
                            //     Quan = "Quận Gò Vấp",
                            //     ThanhPho = "TPHCM"
                            // },
                            //DiaChi = new KhachHang.DiaChiNha("12.34", "Tân Sơn", "Phường 15", "Quận Tân Bình", "TPHCM")
                        }
                    );

                }
            }
            context.SaveChanges();

        }

        private static string GetMd5Hash(MD5 md5, string input)
        {
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                s.Append(bytes[i].ToString("X2"));

            }
            return s.ToString();

        }
    }

}