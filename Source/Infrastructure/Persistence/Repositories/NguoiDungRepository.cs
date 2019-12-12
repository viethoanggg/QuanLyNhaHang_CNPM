using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IRepositories;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories {
    public class NguoiDungRepository : Repository<NguoiDung>, INguoiDungRepository {
        public NguoiDungRepository (QLNHContext context) : base (context) {

        }
        public void Update(NguoiDung NguoiDung)
        {
            QLNHContext.Entry(NguoiDung).State = EntityState.Modified;
        }
        protected QLNHContext QLNHContext {
            get { return Context as QLNHContext; }
        }
    }
}