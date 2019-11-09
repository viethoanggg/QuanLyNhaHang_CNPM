using System.Reflection.Metadata;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace QuanLyNhaHang.Controllers
{
    public class HoaDonController : Controller
    {
        private readonly IHoaDonServices _services;
        private readonly IMapper _mapper;
        public HoaDonController(IHoaDonServices services, IMapper mapper)
        {
            this._services = services;
            this._mapper = mapper;
        }
        public IActionResult Index(int pageIndex = 1)
        {
            return View(_services.GetHoaDonVM(pageIndex));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            HoaDonDTO hoaDonDTO = _services.FindHD(id.Value);
            if (hoaDonDTO == null)
                return RedirectToAction("Index");
            SaveHoaDonDTO saveHoaDonDTO = _mapper.Map<HoaDonDTO, SaveHoaDonDTO>(hoaDonDTO);
            return View(saveHoaDonDTO);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Deleted(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            HoaDonDTO hoaDonDTO = _services.FindHD(id.Value);
            if (hoaDonDTO == null)
                return RedirectToAction("Index");

            BanAnDTO baDTO = _services.FindBanAn(id.Value);
            SaveHoaDonDTO saveHoaDonDTO = _mapper.Map<HoaDonDTO, SaveHoaDonDTO>(hoaDonDTO);

            if (baDTO.TrangThai.Equals("Đang phục vụ"))
            {
                ViewBag.Error = "Bàn ăn đang được phục vụ ,không thể xóa ";
                return View(saveHoaDonDTO);
            }
            _services.Delete(saveHoaDonDTO);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            HoaDonDTO hoaDonDTO = _services.FindHD(id.Value);
            if (hoaDonDTO == null)
                return RedirectToAction("Index");
            return View(hoaDonDTO);
        }
    }
}