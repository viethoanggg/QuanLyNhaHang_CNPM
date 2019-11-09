using System.Collections.Generic;
using ApplicationCore.Entitites;
using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Services.Interfaces
{
    public interface IPhieuDatBanServices
    {
        PhieuDatBanVM GetPhieuDatBanVM(int pageIndex);
        PhieuDatBan GetById(int Id);
        void Update(PhieuDatBan p);
        int Add(PhieuDatBan p);
        void Delete(PhieuDatBan p);
        IEnumerable<BanAn> GetListBanAn();
    }
}