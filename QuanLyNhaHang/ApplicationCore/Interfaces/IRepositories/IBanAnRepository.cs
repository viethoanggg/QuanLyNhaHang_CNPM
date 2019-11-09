using ApplicationCore.Entitites;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IBanAnRepository:IRepository<BanAn>
    {
        void Update(BanAn banAn);       
    }
  
}