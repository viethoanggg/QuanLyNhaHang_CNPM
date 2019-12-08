using System.Collections.Generic;
using System.Reflection.Emit;
using ApplicationCore.DTOs;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.Services;

namespace ApplicationCore.ModelsContainData.ViewModels {
    public class HoaDonVM {
        public PaginatedList<HoaDonMD> ListHoaDonMD { get; set; }
        public HoaDonDTO HoaDon { get; set; }
        public IEnumerable<CTHDMD> ChiTietHoaDonMD { get; set; }
    }
}