using ApplicationCore.DTOs;
using ApplicationCore.Entitites;
using ApplicationCore.Services;

namespace ApplicationCore.ModelsContainData.ViewModels
{
    public class LoaiMonAnVM
    {
        public PaginatedList<LoaiMonAnDTO> LoaiMonAns{ get; set; }
    }
}