using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.ModelsContainData.Models;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IHoaDonRepository : IRepository<HoaDon>
    {
        void Update(HoaDon HoaDon);
        Task ThemCTHD(int IdHoaDon, int IdMonAn, int SoLuong);
        IEnumerable<ChiTietHoaDon> GetListCTHD(int IdHoaDon);
        HoaDon CapNhatTongTien(int IdHoaDon);
        BanAn FindBanAn(int IdHoaDon);
        void DeleteCTHD(int IdHoaDon, int IdMonAn);
        int DeleteAllCTHD(int IdHoaDon);
        IEnumerable<CTHDMD> GetListCTHDMD(int IdHoaDon);
        IEnumerable<HoaDonMD> GetListHoaDonMD(IEnumerable<HoaDon> listHD);
        IEnumerable<ThongKeSLMonAnMD> GetThongKeSLMonAnBanDuoc(IEnumerable<ThongKeSLMonAnMD> listThongKe, IEnumerable<HoaDon> listHD);
        int GetThongKeTongDoanhThu(Expression<Func<HoaDon, bool>> predicate);
        int GetTongSoBanAnDuocPhucVu(Expression<Func<HoaDon, bool>> predicate);
    }
}