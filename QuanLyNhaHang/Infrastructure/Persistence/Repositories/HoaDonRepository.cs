using ApplicationCore.Entitites;
using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories
{
    public class HoaDonRepository:Repository<HoaDon>,IHoaDonRepository
    {
        public HoaDonRepository(QLNHContext context):base(context)
        {

        }
        protected QLNHContext QLNHContext
        {
            get { return Context as QLNHContext; }
        }
    }
}