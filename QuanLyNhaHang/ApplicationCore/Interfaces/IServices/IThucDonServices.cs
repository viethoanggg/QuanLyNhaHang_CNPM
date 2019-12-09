using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.ModelsContainData.ViewModels;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IThucDonServices
    {
        IEnumerable<ThucDonMD> GetListThucDonMD(string searchString, int giaTu, int GiaDen, int pageIndex, int pageSize, out int count);
        IEnumerable<LoaiMonAnDTO> GetLoaiMonAns();
        ThucDonDTO GetMonAn(int id);
        ThucDonMD GetMonAnMD(int id);
        void Create(SaveThucDonDTO td);
        void Edit(SaveThucDonDTO td);
        void Remove(int id);
    }
}