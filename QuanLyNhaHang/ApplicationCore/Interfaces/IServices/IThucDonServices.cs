using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entitites;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.ModelsContainData.ViewModels;

namespace ApplicationCore.Interfaces.IServices
{
    public interface IThucDonServices
    {
        ThucDonVM GetThucDonVM(string sort, string searchString, string currentFilter, string tenLoaiMonAn, int pageIndex);
        IEnumerable<LoaiMonAnDTO> GetLoaiMonAns();
        ThucDonDTO GetMonAn(int id);
        ThucDonMD GetMonAnMD(int id);
        void Create(SaveThucDonDTO td);
        void Edit(SaveThucDonDTO td);
        void Remove(int id);
    }
}