using System;
using ApplicationCore.Interfaces.IRepositories;

namespace ApplicationCore.Interfaces {
    public interface IUnitOfWork : IDisposable {

        IThucDonRepository ThucDons { get; }
        IBanAnRepository BanAns { get; }
        IHoaDonRepository HoaDons { get; }
        ILoaiMonAnRepository LoaiMonAns { get; }
        IKhachHangRepository KhachHangs { get; }
        IPhieuDatBanRepository PhieuDatBans { get; }
        INguoiDungRepository NguoiDungs { get; }
        int Complete ();
    }
}