using ApplicationCore.Entitites;

namespace ApplicationCore.Interfaces
{
    public interface IKhachHangRepository : IRepository<KhachHang>
    {
        void Update(KhachHang khachHang);
    }
}