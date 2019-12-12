

using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface ILoaiMonAnRepository:IRepository<LoaiMonAn>
    {
        void Update(LoaiMonAn loaiMonAn);
    }
}