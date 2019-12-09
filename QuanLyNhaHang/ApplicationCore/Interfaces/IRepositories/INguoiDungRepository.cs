using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface INguoiDungRepository : IRepository<NguoiDung>
    {
        void Update(NguoiDung NguoiDung);
    }
}