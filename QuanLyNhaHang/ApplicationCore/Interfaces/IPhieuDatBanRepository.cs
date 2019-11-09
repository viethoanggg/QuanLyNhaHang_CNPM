using ApplicationCore.Entitites;

namespace ApplicationCore.Interfaces
{
    public interface IPhieuDatBanRepository:IRepository<PhieuDatBan>
    {
        void Update(PhieuDatBan p);
    }
}