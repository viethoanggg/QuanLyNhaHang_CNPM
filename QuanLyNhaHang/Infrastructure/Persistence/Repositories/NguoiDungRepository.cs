using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IRepositories;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories {
    public class NguoiDungRepository : Repository<NguoiDung>, INguoiDungRepository {
        public NguoiDungRepository (QLNHContext context) : base (context) {

        }
        protected QLNHContext QLNHContext {
            get { return Context as QLNHContext; }
        }
    }
}