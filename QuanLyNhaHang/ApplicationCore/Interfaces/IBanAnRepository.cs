using ApplicationCore.Entitites;

namespace ApplicationCore.Interfaces
{
    public interface IBanAnRepository:IRepository<BanAn>
    {
        void Update(BanAn banAn);       
    }
  
}