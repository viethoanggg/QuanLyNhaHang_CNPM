using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entitites;
using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories
{
    public class HoaDonRepository:Repository<HoaDon>,IHoaDonRepository
    {
        public HoaDonRepository(QLNHContext context):base(context)
        {

        }
        public void ThemCTDH(int IdHoaDon,int IdMonAn,int SoLuong)
        {
            ThucDon td = QLNHContext.ThucDons.Where(s=>s.Id==IdMonAn).FirstOrDefault();
            ChiTietHoaDon chiTiet = QLNHContext.ChiTietHoaDons.Where(s => s.IdHoaDon == IdHoaDon && s.IdMonAn == IdMonAn).FirstOrDefault();
            if(chiTiet==null)
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

        public int? TongTien(int IdHoaDon)
        {
            int? sum = 0;
            IEnumerable<ChiTietHoaDon> a= QLNHContext.ChiTietHoaDons.Where(s => s.IdHoaDon == IdHoaDon);
            foreach ( ChiTietHoaDon i in a)
            {
                sum = sum + i.DonGia;
            }
            return sum;
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

        protected QLNHContext QLNHContext
        {
            get { return Context as QLNHContext; }
        }
    }
}