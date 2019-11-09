using System.Reflection.Emit;
using ApplicationCore.DTOs;
using ApplicationCore.Entitites;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.Services;

namespace ApplicationCore.ModelsContainData.ViewModels
{
    public class HoaDonVM
    {
        public PaginatedList<HoaDonDTO> HoaDons{ get; set; }
        public CTHDMD ChiTietHoaDonMD{ get; set; }
    }
}