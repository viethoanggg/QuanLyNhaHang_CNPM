using System;

namespace ApplicationCore.Interfaces {
    public interface IUnitOfWork : IDisposable {

        IThucDonRepository ThucDons { get; }
        IBanAnRepository BanAns{ get; }
        IHoaDonRepository HoaDons { get; }
        ILoaiMonAnRepository LoaiMonAns { get; }
        int Complete ();
    }
}