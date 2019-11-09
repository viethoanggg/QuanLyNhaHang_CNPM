using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IPhieuDatBanRepository:IRepository<PhieuDatBan>
    {
        void Update(PhieuDatBan p);
    }
}