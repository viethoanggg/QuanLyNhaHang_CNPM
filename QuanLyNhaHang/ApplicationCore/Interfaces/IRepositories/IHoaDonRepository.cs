using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IHoaDonRepository:IRepository<HoaDon>
    {
        void Update(HoaDon HoaDon);
        void ThemCTHD(int IdHoaDon, int IdMonAn, int SoLuong);
        IEnumerable<ChiTietHoaDon> GetListCTHD(int IdHoaDon);
        HoaDon CapNhatTongTien(int IdHoaDon);
        BanAn FindBanAn(int IdHoaDon);
        void DeleteCTHD(int IdHoaDon,int IdMonAn);
        int DeleteAllCTHD(int IdHoaDon);
    }
}