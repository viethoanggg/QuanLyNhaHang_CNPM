using ApplicationCore.Entitites;
using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Data;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Repositories
{
    public class LoaiMonAnRepository : Repository<LoaiMonAn>,ILoaiMonAnRepository
    {
        public LoaiMonAnRepository(QLNHContext context) : base(context)
        {
        }
        
        
=======

namespace Infrastructure.Persistence.Repositories
{
    public class LoaiMonAnRepository:Repository<LoaiMonAn>,ILoaiMonAnRepository
    {
        public LoaiMonAnRepository(QLNHContext context):base(context)
        {

        }
>>>>>>> e9198c7eb3a960604141cd27eb6bb4661b89820b
        protected QLNHContext QLNHContext
        {
            get { return Context as QLNHContext; }
        }
<<<<<<< HEAD
=======
    
>>>>>>> e9198c7eb3a960604141cd27eb6bb4661b89820b
    }
}