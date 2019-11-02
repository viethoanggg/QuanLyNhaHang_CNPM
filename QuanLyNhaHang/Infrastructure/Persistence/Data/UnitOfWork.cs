using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositoties;

namespace Infrastructure.Persistence.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private QLNHContext context{ get; set; }
        public IThucDonRepository ThucDons{ get; private set; }
        public UnitOfWork(QLNHContext context)
        {
            this.context = context;
            ThucDons = new ThucDonRepository(context);
        }
        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}