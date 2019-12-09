using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.ModelsContainData.ViewModels;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infrastructure.Persistence.Repositories
{
    public class PhieuDatBanRepository : Repository<PhieuDatBan>, IPhieuDatBanRepository
    {
        public PhieuDatBanRepository(QLNHContext context) : base(context)
        {

        }

        protected QLNHContext QLNHContext
        {
            get { return Context as QLNHContext; }
        }

        public void CapNhatAllPhieuDatBan()
        {
            DateTime day = DateTime.Now;

            IEnumerable<PhieuDatBan> phieuDatBans = QLNHContext.PhieuDatBans.Where(s => s.TrangThai == "Chưa xử lý");

            foreach (PhieuDatBan p in phieuDatBans)
            {
                if (p.TrangThai == "Chưa xử lý")
                {
                    int compare = DateTime.Compare(day, p.ThoiGianDat + new TimeSpan(0, 1, 30, 0));
                    //nếu quá 1h30 so với thời gian đặt thì sẽ bị hủy
                    if (compare > 0)
                    {
                        p.TrangThai = "Bị hủy";
                        BanAn b = QLNHContext.BanAns.Where(s => s.Id == p.IdBanAn).FirstOrDefault();
                        b.TrangThai = "Trống";

                        QLNHContext.Entry(b).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        QLNHContext.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                        QLNHContext.SaveChanges();
                    }
                }

            }
        }
        public IEnumerable<PhieuDatBanMD> GetListPhieuDatBanMD(IEnumerable<PhieuDatBan> phieuDatBans)
        {

            IEnumerable<PhieuDatBanMD> phieuDatBanMDs = phieuDatBans.Join(QLNHContext.KhachHangs, s => s.IdKhachHang, t => t.Id,
                                                                    (s, t) => new PhieuDatBanMD
                                                                    {
                                                                        Id = s.Id,
                                                                        IdBanAn = s.IdBanAn,
                                                                        IdKhachHang = s.IdKhachHang,
                                                                        TenKhachHang = t.Ten,
                                                                        ThoiGianDat = s.ThoiGianDat,
                                                                        TrangThai = s.TrangThai,
                                                                        GhiChu = s.GhiChu

                                                                    });
            return phieuDatBanMDs;

        }
        public void Update(PhieuDatBan p)
        {
            QLNHContext.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public int GetIdBanAn(int IdPhieuDatBan)
        {
            return QLNHContext.PhieuDatBans.Where(s => s.Id == IdPhieuDatBan).Select(s => s.IdBanAn).FirstOrDefault();
        }


        public int ThemPhieuDatBan(PhieuDatBan phieuDatBan)
        {

            KhachHang kh = QLNHContext.KhachHangs.Where(s => s.Id == phieuDatBan.IdKhachHang).FirstOrDefault();
            if (kh == null)
                return -2;

            //Kiểm tra thời gian phiếu đặt bàn
            int i = KiemTraThoiGianTrung(phieuDatBan);
            if (i == 0)
                return 0;

            // khi phiếu đặt bàn ko bị trùng thời gian
            phieuDatBan.TrangThai = "Chưa xử lý";
            QLNHContext.PhieuDatBans.Add(phieuDatBan);

            // Kiểm tra thời gian hiện tại cho phiếu đặt bàn
            UpdateBanAnCuaPhieuDatBanInTimeNow(phieuDatBan);

            return 1;
        }

        public int KiemTraThoiGianTrung(PhieuDatBan phieuDatBan)
        {
            //Kiểm tra thời gian phiếu đặt bàn
            //nếu nằm trong khoảng thời gian phục vị tồi đa của phiếu đặt bàn khác thì ko thể thêm phiếu
            IEnumerable<PhieuDatBan> list = QLNHContext.PhieuDatBans.Where(s => s.TrangThai == "Chưa xử lý");
            DateTime tg = phieuDatBan.ThoiGianDat + new TimeSpan(0, 3, 0, 0);
            foreach (var p in list)
            {
                if (p.IdBanAn == phieuDatBan.IdBanAn)
                {
                    if ((DateTime.Compare(phieuDatBan.ThoiGianDat, p.ThoiGianDat) >= 0 && DateTime.Compare(phieuDatBan.ThoiGianDat, p.ThoiGianDat + new TimeSpan(0, 3, 0, 0)) <= 0) || (DateTime.Compare(tg, p.ThoiGianDat) >= 0 && DateTime.Compare(tg, p.ThoiGianDat + new TimeSpan(0, 3, 0, 0)) <= 0))
                        return 0;
                }
            }

            return 1;
        }

        public void UpdateBanAnCuaPhieuDatBanInTimeNow(PhieuDatBan phieuDatBan)
        {

            // Kiểm tra thời gian hiện tại cho phiếu đặt bàn
            BanAn ba = QLNHContext.BanAns.Where(s => s.Id == phieuDatBan.IdBanAn).FirstOrDefault();
            DateTime now = DateTime.Now;
            DateTime nowCong3h = DateTime.Now + new TimeSpan(0, 3, 0, 0);
            DateTime tg = phieuDatBan.ThoiGianDat + new TimeSpan(0, 3, 0, 0);

            if ((now >= phieuDatBan.ThoiGianDat && now <= tg) || (nowCong3h >= phieuDatBan.ThoiGianDat && nowCong3h <= tg))
            {
                ba.TrangThai = "Được đặt trước";
                QLNHContext.Entry(ba).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }
        public int GetThongKeTongPhieuDatBan()
        {
            int tongPhieuDatBan = 0;
            IEnumerable<PhieuDatBan> listPhieuDatBan = QLNHContext.PhieuDatBans.ToList();
            tongPhieuDatBan = listPhieuDatBan.Count();
            return tongPhieuDatBan;
        }
        public int GetThongKePhieuDatBanBiHuy()
        {
            int tongPhieuDatBan = 0;
            IEnumerable<PhieuDatBan> listPhieuDatBan = QLNHContext.PhieuDatBans.Where(s => s.TrangThai.Equals("Bị hủy")).ToList();
            tongPhieuDatBan = listPhieuDatBan.Count();
            return tongPhieuDatBan;
        }
        public int GetThongKePhieuDatBanXuLyXong()
        {
            int tongPhieuDatBan = 0;
            IEnumerable<PhieuDatBan> listPhieuDatBan = QLNHContext.PhieuDatBans.Where(s => s.TrangThai.Equals("Xử lý xong")).ToList();
            tongPhieuDatBan = listPhieuDatBan.Count();
            return tongPhieuDatBan;
        }
        public int GetThongKePhieuDatBanChuaXuLy()
        {
            int tongPhieuDatBan = 0;
            IEnumerable<PhieuDatBan> listPhieuDatBan = QLNHContext.PhieuDatBans.Where(s => s.TrangThai.Equals("Chưa xử lý")).ToList();
            tongPhieuDatBan = listPhieuDatBan.Count();
            return tongPhieuDatBan;
        }
    }
}