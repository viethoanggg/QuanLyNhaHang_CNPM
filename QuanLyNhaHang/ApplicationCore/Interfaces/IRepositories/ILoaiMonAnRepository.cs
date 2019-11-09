using ApplicationCore.Entitites;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface ILoaiMonAnRepository:IRepository<LoaiMonAn>
    {
        void Update(LoaiMonAn loaiMonAn);
    }
}