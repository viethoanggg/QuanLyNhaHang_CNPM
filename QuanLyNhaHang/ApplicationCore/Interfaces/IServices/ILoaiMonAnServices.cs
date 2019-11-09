using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entitites;
using ApplicationCore.ModelsContainData.ViewModels;

namespace ApplicationCore.Interfaces.IServices
{
    public interface ILoaiMonAnServices
    {
        LoaiMonAnVM GetLoaiMonAnVM(int pageIndex);
        LoaiMonAnDTO GetLoaiMonAn(int id);
        void Edit(SaveLoaiMonAnDTO loaiMonAn);
        void Delete(int id);
        void Create(SaveLoaiMonAnDTO loaiMonAn);
    }
}