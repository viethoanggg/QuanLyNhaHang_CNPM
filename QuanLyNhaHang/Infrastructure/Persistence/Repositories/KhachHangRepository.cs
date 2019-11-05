using ApplicationCore.Entitites;
using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class KhachHangRepository:Repository<KhachHang>,IKhachHangRepository
    {
        public KhachHangRepository(QLNHContext context ) :base(context)
        {
            
        }
        protected QLNHContext QLNHContext
        {
            get { return Context as QLNHContext; }
        }

        public void Update(KhachHang khachHang)
        {
            QLNHContext.Entry(khachHang).State = EntityState.Modified;
        }
    }
}