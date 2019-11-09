using ApplicationCore.Entitites;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IRepositories;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Repositories 
{
    public class LoaiMonAnRepository : Repository<LoaiMonAn>, ILoaiMonAnRepository 
    {
        public LoaiMonAnRepository (QLNHContext context) : base (context) 
        {
        }

        

       protected QLNHContext QLNHContext 
       {               
            get { return Context as QLNHContext; }
       }
        public void Update(LoaiMonAn loaiMonAn)
        {
            QLNHContext.Entry(loaiMonAn).State = EntityState.Modified;
        }
        
        
    }
}