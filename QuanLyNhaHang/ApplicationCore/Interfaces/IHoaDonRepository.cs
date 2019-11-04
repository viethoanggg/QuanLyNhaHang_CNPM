using System.Collections.Generic;
using ApplicationCore.Entitites;

namespace ApplicationCore.Interfaces
{
    public interface IHoaDonRepository:IRepository<HoaDon>
    {
        void Update(HoaDon HoaDon);
        void ThemCTDH(int IdHoaDon, int IdMonAn, int SoLuong);
        IEnumerable<ChiTietHoaDon> GetListCTHD(int IdHoaDon);
        int? TongTien(int IdHoaDon);
        BanAn FindBanAn(int IdHoaDon);
    }
}