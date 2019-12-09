using System.Security.Principal;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IRepositories;
using Infrastructure.Persistence.Data;
using System.Threading.Tasks;
using ApplicationCore.ModelsContainData.Models;

namespace Infrastructure.Persistence.Repositories
{
    public class HoaDonRepository : Repository<HoaDon>, IHoaDonRepository
    {
        public HoaDonRepository(QLNHContext context) : base(context)
        {

        }
        public async Task ThemCTHD(int IdHoaDon, int IdMonAn, int SoLuong)
        {
            ThucDon td = QLNHContext.ThucDons.Where(s => s.Id == IdMonAn).FirstOrDefault();
            ChiTietHoaDon chiTiet = QLNHContext.ChiTietHoaDons.Where(s => s.IdHoaDon == IdHoaDon && s.IdMonAn == IdMonAn).FirstOrDefault();
            if (chiTiet == null)
            {
                ChiTietHoaDon ct = new ChiTietHoaDon
                {
                    IdHoaDon = IdHoaDon,
                    IdMonAn = IdMonAn,
                    SoLuong = SoLuong,
                    DonGia = td.Gia * SoLuong
                };
                await QLNHContext.ChiTietHoaDons.AddAsync(ct);
            }
            else
            {
                chiTiet.SoLuong = SoLuong;
                chiTiet.DonGia = SoLuong * td.Gia;
                QLNHContext.Entry(chiTiet).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

        }
        public void Update(HoaDon HoaDon)
        {
            QLNHContext.Entry(HoaDon).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public HoaDon CapNhatTongTien(int IdHoaDon)
        {
            int sum = 0;
            IEnumerable<ChiTietHoaDon> a = QLNHContext.ChiTietHoaDons.Where(s => s.IdHoaDon == IdHoaDon);
            foreach (ChiTietHoaDon i in a)
            {
                sum = sum + i.DonGia;
            }
            HoaDon hoaDon = QLNHContext.HoaDons.Where(s => s.Id == IdHoaDon).FirstOrDefault();
            hoaDon.ThanhTien = sum;
            Update(hoaDon);
            return hoaDon;
        }
        public IEnumerable<ChiTietHoaDon> GetListCTHD(int IdHoaDon)
        {
            IEnumerable<ChiTietHoaDon> list = QLNHContext.ChiTietHoaDons.Where(s => s.IdHoaDon == IdHoaDon);
            return list;
        }

        public BanAn FindBanAn(int IdHoaDon)
        {
            HoaDon hd = QLNHContext.HoaDons.Where(s => s.Id == IdHoaDon).FirstOrDefault();
            BanAn ba = QLNHContext.BanAns.Where(s => s.Id == hd.IdBanAn).FirstOrDefault();
            return ba;
        }

        public void DeleteCTHD(int IdHoaDon, int IdMonAn)
        {
            ChiTietHoaDon chiTiet = QLNHContext.ChiTietHoaDons.Where(s => s.IdHoaDon == IdHoaDon && s.IdMonAn == IdMonAn).FirstOrDefault();
            QLNHContext.Entry(chiTiet).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

        }
        public int DeleteAllCTHD(int IdHoaDon)
        {
            HoaDon hoaDon = GetById(IdHoaDon);
            BanAn ba = QLNHContext.BanAns.Where(s => s.Id == hoaDon.IdBanAn).FirstOrDefault();
            if (hoaDon == null)
                return -1;
            if (hoaDon.TrangThai.Equals("Chưa thanh toán") && ba.TrangThai.Equals("Đang phục vụ"))
                return 0;
            IEnumerable<ChiTietHoaDon> list = QLNHContext.ChiTietHoaDons.Where(s => s.IdHoaDon == hoaDon.Id);
            QLNHContext.ChiTietHoaDons.RemoveRange(list);
            Remove(hoaDon);
            return 1;
        }
        public IEnumerable<CTHDMD> GetListCTHDMD(int IdHoaDon)
        {
            var cts = GetListCTHD(IdHoaDon);
            IEnumerable<CTHDMD> list = from s in cts
                                       join t in QLNHContext.ThucDons
                                       on s.IdMonAn equals t.Id
                                       select new CTHDMD
                                       {
                                           IdHoaDon = s.IdHoaDon,
                                           IdMonAn = s.IdMonAn,
                                           TenMonAn = t.Ten,
                                           SoLuong = s.SoLuong,
                                           DonGia = s.DonGia
                                       };
            return list.ToList();
        }
        public IEnumerable<HoaDonMD> GetListHoaDonMD(IEnumerable<HoaDon> listHD)
        {
            IEnumerable<HoaDonMD> list = listHD.Join(QLNHContext.NguoiDungs, h => h.IdUser, nd => nd.Id,
                                         (h, nd) => new HoaDonMD
                                         {
                                             Id = h.Id,
                                             IdBanAn = h.IdBanAn,
                                             IdUser = h.IdUser,
                                             TenNhanVien = nd.Ten,
                                             ThoiGianLap = h.ThoiGianLap,
                                             ThoiGianThanhToan = h.ThoiGianThanhToan,
                                             ThanhTien = h.ThanhTien,
                                             TrangThai = h.TrangThai
                                         });
            return list;
        }
        protected QLNHContext QLNHContext
        {
            get { return Context as QLNHContext; }
        }
    }
}