using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IRepositories;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class BanAnRepository : Repository<BanAn>, IBanAnRepository
    {
        public BanAnRepository(QLNHContext context) : base(context)
        {
        }

        public void Update(BanAn banAn)
        {
            QLNHContext.Entry(banAn).State = EntityState.Modified;
        }

        public void BanAn_Load()
        {
            IEnumerable<PhieuDatBan> phieuDatBans = QLNHContext.PhieuDatBans.Where(s => s.TrangThai =="Chưa xử lý");

            // cập nhật trạng thái bàn đặt trước, nếu qua thời gian quy đinh thì sẽ bị hủy
            TimeSpan aInterval = new System.TimeSpan(0, -1, -30, 0);
            // trừ một khoảng thời gian.
            DateTime day = DateTime.Now;
            DateTime dayNow = DateTime.Now;
            day = day.Add(aInterval);

            var banDatTruocs = QLNHContext.BanAns.Where(s => s.TrangThai == "Được đặt trước");
            foreach (BanAn ban in banDatTruocs)
            {

                foreach (PhieuDatBan p in phieuDatBans)
                {               
                        int compare = DateTime.Compare(day, p.ThoiGianDat);
                        if (compare > 0 && ban.Id == p.IdBanAn)
                        {
                            ban.TrangThai = "Trống";
                            Update(ban);
                            p.TrangThai = "Bị hủy";
                            QLNHContext.Entry(p).State = EntityState.Modified;
                            QLNHContext.SaveChanges();
                        }
                    
                }
            }

            // cập nhật trạng thái bàn trống,nếu có người đặt bàn mà chưa tới giờ phục vụ
            // thì trong khoảng thời gian phục vụ tồi đa là 3 tiếng
            // thì sẽ cập nhật bàn ăn là dc đặt trước

            day = DateTime.Now;

            var banTrongs = QLNHContext.BanAns.Where(s => s.TrangThai == "Trống");
            foreach (BanAn ban in banTrongs)
            {
                foreach (PhieuDatBan p in phieuDatBans)
                {
                    
                        DateTime.Compare(day, p.ThoiGianDat);
                        if (ban.Id == p.IdBanAn && (DateTime.Compare(day, p.ThoiGianDat + new TimeSpan(0, -3, 0, 0)) >= 0 && DateTime.Compare(day, p.ThoiGianDat + new TimeSpan(0, 1, 30, 0)) <= 0))
                        {
                            ban.TrangThai = "Được đặt trước";
                            Update(ban);
                            QLNHContext.SaveChanges();
                        }
                }
            }
        }
        protected QLNHContext QLNHContext
        {
            get { return Context as QLNHContext; }
        }
    }
}