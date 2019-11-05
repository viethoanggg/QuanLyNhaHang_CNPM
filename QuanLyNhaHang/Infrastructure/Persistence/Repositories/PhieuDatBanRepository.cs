using ApplicationCore.Entitites;
using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories
{
    public class PhieuDatBanRepository : Repository<PhieuDatBan>, IPhieuDatBanRepository
    {
       public PhieuDatBanRepository(QLNHContext context) :base(context)
       {
           
       }

        protected QLNHContext QLNHContext{
            get { return Context as QLNHContext; }
        }
    }
}