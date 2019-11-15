using System.Security.Principal;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IRepositories;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories
{
    public class HoaDonRepository : Repository<HoaDon>, IHoaDonRepository
    {
        public HoaDonRepository(QLNHContext context) : base(context)
        {

        }
        public void ThemCTHD(int IdHoaDon, int IdMonAn, int SoLuong)
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
                QLNHContext.ChiTietHoaDons.Add(ct);
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
            if(hoaDon == null)
                return -1;
            if (hoaDon.TrangThai.Equals("Chưa thanh toán") && ba.TrangThai.Equals("Đang phục vụ"))
                return 0;
            IEnumerable<ChiTietHoaDon> list = QLNHContext.ChiTietHoaDons.Where(s => s.IdHoaDon == hoaDon.Id);
            QLNHContext.ChiTietHoaDons.RemoveRange(list);
            Remove(hoaDon);
            return 1;
        }
        protected QLNHContext QLNHContext
        {
            get { return Context as QLNHContext; }
        }
    }
}