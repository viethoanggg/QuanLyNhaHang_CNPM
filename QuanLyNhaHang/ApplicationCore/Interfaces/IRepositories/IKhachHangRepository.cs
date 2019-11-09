using ApplicationCore.Entitites;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IKhachHangRepository : IRepository<KhachHang>
    {
        void Update(KhachHang khachHang);
      
    }
}