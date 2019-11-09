using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.ModelsContainData.ViewModels;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IPhieuDatBanServices
    {
        PhieuDatBanVM GetPhieuDatBanVM(int pageIndex);
        PhieuDatBanDTO GetById(int Id);
        void Update(SavePhieuDatBanDTO p);
        int Add(SavePhieuDatBanDTO p);
        void Delete(int id);
        IEnumerable<BanAnDTO> GetListBanAn();
    }
}