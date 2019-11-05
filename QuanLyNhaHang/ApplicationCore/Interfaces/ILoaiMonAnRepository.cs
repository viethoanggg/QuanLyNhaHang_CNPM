using ApplicationCore.Entitites;

namespace ApplicationCore.Interfaces
{
    public interface ILoaiMonAnRepository:IRepository<LoaiMonAn>
    {
        void Update(LoaiMonAn loaiMonAn);
    }
}