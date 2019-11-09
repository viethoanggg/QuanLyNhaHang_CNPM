using ApplicationCore.Entitites;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IPhieuDatBanRepository:IRepository<PhieuDatBan>
    {
        void Update(PhieuDatBan p);
    }
}