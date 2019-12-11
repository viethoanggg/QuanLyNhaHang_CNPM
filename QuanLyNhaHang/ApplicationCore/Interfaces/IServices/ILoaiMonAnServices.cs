using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;


namespace ApplicationCore.Interfaces.IServices
{
    public interface ILoaiMonAnServices
    {
        IEnumerable<LoaiMonAnDTO> GetListLoaiMonAn(string searchString, int pageIndex, int pageSize, out int count);
        LoaiMonAnDTO GetLoaiMonAn(int id);
        void Edit(SaveLoaiMonAnDTO loaiMonAn);
        void Delete(int id);
        void Create(SaveLoaiMonAnDTO loaiMonAn);
    }
}