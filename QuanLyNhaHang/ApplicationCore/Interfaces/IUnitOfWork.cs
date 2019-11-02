using System;

namespace ApplicationCore.Interfaces {
    public interface IUnitOfWork : IDisposable {

        IThucDonRepository ThucDons { get; }
        int Complete ();
    }
}