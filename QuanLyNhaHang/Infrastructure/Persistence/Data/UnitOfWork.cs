using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;


namespace Infrastructure.Persistence.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private QLNHContext context { get; set; }
        public IThucDonRepository ThucDons { get; private set; }
        public IBanAnRepository BanAns { get; private set; }
        public IHoaDonRepository HoaDons { get; private set; }
        public ILoaiMonAnRepository LoaiMonAns{ get; private set; }
        public UnitOfWork(QLNHContext context)
        {
            this.context = context;
            ThucDons = new ThucDonRepository(context);
            BanAns = new BanAnRepository(context);
            HoaDons = new HoaDonRepository(context);
            LoaiMonAns = new LoaiMonAnRepository(context);
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