using ApplicationCore.DTOs;
using ApplicationCore.Entitites;
using ApplicationCore.Services;

namespace ApplicationCore.ModelsContainData.ViewModels
{
    public class KhachHangVM
    {
        public PaginatedList<KhachHangDTO> KhachHangs{ get; set; }
    }
}