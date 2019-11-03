using ApplicationCore.Entitites;
using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class BanAnRepository : Repository<BanAn>, IBanAnRepository
    {
        public BanAnRepository(QLNHContext context) : base(context)
        {
        }

        public void Update(BanAn banAn)
        {
            QLNHContext.Entry(banAn).State = EntityState.Modified;
        }
        protected QLNHContext QLNHContext
        {
            get { return Context as QLNHContext; }
        }
    }
}