using ApplicationCore.Entitites;
using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories
{
    public class LoaiMonAnRepository:Repository<LoaiMonAn>,ILoaiMonAnRepository
    {
        public LoaiMonAnRepository(QLNHContext context):base(context)
        {

        }
        protected QLNHContext QLNHContext
        {
            get { return Context as QLNHContext; }
        }
    
    }
}