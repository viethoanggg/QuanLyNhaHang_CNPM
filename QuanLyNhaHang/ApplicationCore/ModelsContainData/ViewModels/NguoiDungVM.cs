using ApplicationCore.DTOs;
using ApplicationCore.Services;

namespace ApplicationCore.ModelsContainData.ViewModels
{
    public class NguoiDungVM
    {
        public PaginatedList<NguoiDungDTO> NguoiDungs { get; set; }
    }
}