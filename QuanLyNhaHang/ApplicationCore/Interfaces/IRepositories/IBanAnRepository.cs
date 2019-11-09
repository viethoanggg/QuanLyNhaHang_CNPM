

using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IBanAnRepository:IRepository<BanAn>
    {
        void Update(BanAn banAn);       
    }
  
}