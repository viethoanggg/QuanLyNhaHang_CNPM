using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.Entities;
using ApplicationCore.ModelsContainData.Models;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IPhieuDatBanRepository : IRepository<PhieuDatBan>
    {
        void Update(PhieuDatBan p);
        int GetIdBanAn(int IdPhieuDatBan);
        int ThemPhieuDatBan(PhieuDatBan phieuDatBan);
        int KiemTraThoiGianTrung(PhieuDatBan phieuDatBan);
        void UpdateBanAnCuaPhieuDatBanInTimeNow(PhieuDatBan phieuDatBan);
        void CapNhatAllPhieuDatBan();
        IEnumerable<PhieuDatBanMD> GetListPhieuDatBanMD(IEnumerable<PhieuDatBan> phieuDatBans);
        int GetThongKeTongPhieuDatBan(Expression<Func<PhieuDatBan, bool>> predicate);
        int GetThongKePhieuDatBanBiHuy(Expression<Func<PhieuDatBan, bool>> predicate);
        int GetThongKePhieuDatBanXuLyXong(Expression<Func<PhieuDatBan, bool>> predicate);
        int GetThongKePhieuDatBanChuaXuLy(Expression<Func<PhieuDatBan, bool>> predicate);

    }
}