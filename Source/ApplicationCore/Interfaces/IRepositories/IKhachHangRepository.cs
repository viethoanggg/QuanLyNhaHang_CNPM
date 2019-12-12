using ApplicationCore.Entities;


namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IKhachHangRepository : IRepository<KhachHang>
    {
        void Update(KhachHang khachHang);
        int KiemTraPhieuDatBanCuaKhachHang(int IdKhachHang);
    }
}