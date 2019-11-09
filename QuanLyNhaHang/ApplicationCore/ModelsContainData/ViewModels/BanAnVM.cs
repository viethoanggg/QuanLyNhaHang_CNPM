using ApplicationCore.DTOs;
using ApplicationCore.Services;

namespace ApplicationCore.ModelsContainData.ViewModels
{
    public class BanAnVM
    {
        public PaginatedList<BanAnDTO> BanAns{ get; set; }
    }
}