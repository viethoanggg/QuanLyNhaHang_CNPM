using System;
using System.Data;
using System.Globalization;
using System.Net;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Services.Interfaces;

namespace QuanLyNhaHang.Controllers
{
    public class PhieuDatBanController : Controller
    {
        private readonly IPhieuDatBanServices _services;
        private readonly IPhieuDatBanIndexVMServices _servicesIndexVM;
        private readonly IMapper _mapper;
        public PhieuDatBanController(IPhieuDatBanServices services, IPhieuDatBanIndexVMServices servicesIndexVM, IMapper mapper)
        {
            this._services = services;
            this._servicesIndexVM = servicesIndexVM;
            this._mapper = mapper;
        }

        public bool KiemTraDangNhap()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("TenDangNhapCurrentUser")))
            {
                return false;
            }
            else
            {
                ViewBag.IdCurrentUser = HttpContext.Session.GetString("IdCurrentUser").ToString();
                ViewBag.TenCurrentUser = HttpContext.Session.GetString("TenCurrentUser").ToString();
                return true;
            }
        }

        public IActionResult Index(int idBanAn, string trangThai, string currentSort, string currentFilterIdBanAn, string currentFilterTrangThai, int pageIndex = 1)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");

            if (String.IsNullOrEmpty(idBanAn.ToString()))
                idBanAn = 0;
            if (!idBanAn.Equals(0))
            {
                pageIndex = 1;
            }
            else if (!String.IsNullOrEmpty(currentFilterIdBanAn))
            {
                idBanAn = Convert.ToInt32(currentFilterIdBanAn.ToString());
            }

            if (!String.IsNullOrEmpty(trangThai))
            {
                pageIndex = 1;
            }
            else
            {
                trangThai = currentFilterTrangThai;
            }
            ViewBag.CurrentFilterTrangThai = trangThai;
            ViewBag.CurrentFilterIdBanAn = idBanAn;

            if (String.IsNullOrEmpty(currentSort))
                currentSort = "BanAn_DESC";
            ViewBag.CurrentSortIdBanAn = currentSort.Equals("BanAn_DESC") ? "BanAn_ASC" : "BanAn_DESC";
            ViewBag.CurrentSortTrangThai = currentSort.Equals("TrangThai_DESC") ? "TrangThai_ASC" : "TrangThai_DESC";
            ViewBag.CurrentSortThoiGianDat = currentSort.Equals("ThoiGianDat_DESC") ? "ThoiGianDat_ASC" : "ThoiGianDat_DESC";
            ViewBag.CurrentSortTenKhachHang = currentSort.Equals("TenKhachHang_DESC") ? "TenKhachHang_ASC" : "TenKhachHang_DESC";
            
            ViewBag.CurrentSort = currentSort;
            PhieuDatBanVM vm = _servicesIndexVM.GetPhieuDatBanVM(currentSort, idBanAn, trangThai, pageIndex);
            return View(vm);
        }

        public IActionResult Edit(int? id)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");

            if (id == null)
                return RedirectToAction("Index");
            PhieuDatBanDTO pDTO = _services.GetById(id.Value);
            if (pDTO == null)
                return RedirectToAction("Index");

            SavePhieuDatBanDTO savePhieuDatBanDTO = _mapper.Map<PhieuDatBanDTO, SavePhieuDatBanDTO>(pDTO);
            KhachHang kh = _services.GetKhachHang(savePhieuDatBanDTO.IdKhachHang);
            ViewBag.TenKhachHang = kh.Ten;
            PhieuDatBanVM vm = new PhieuDatBanVM
            {
                PhieuDatBan = savePhieuDatBanDTO,
                BanAns = _services.GetListBanAn()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(PhieuDatBanVM vm)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (_services.Update(vm.PhieuDatBan) == false)
            {
                ViewBag.MessagePhieuDatBan = "Thời gian đặt bị trùng";
                KhachHang kh = _services.GetKhachHang(vm.PhieuDatBan.IdKhachHang);
                ViewBag.TenKhachHang = kh.Ten;
                vm = new PhieuDatBanVM
                {
                    PhieuDatBan = vm.PhieuDatBan,
                    BanAns = _services.GetListBanAn()
                };
                return View(vm);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Create(int? IdKhachHang)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");

            PhieuDatBanVM vm = null;
            System.DateTime day = DateTime.Now;
            ViewBag.CurrentTime = DateTime.Now;

            if (IdKhachHang == null)
            {

                vm = new PhieuDatBanVM
                {
                    PhieuDatBan = new SavePhieuDatBanDTO
                    {
                        ThoiGianDat = Convert.ToDateTime(day),
                    },
                    BanAns = _services.GetListBanAn(),
                    KhachHangs = _services.GetListKH()
                };

            }
            else
            {
                vm = new PhieuDatBanVM
                {
                    PhieuDatBan = new SavePhieuDatBanDTO
                    {
                        IdKhachHang = IdKhachHang.Value,
                        ThoiGianDat = Convert.ToDateTime(day),
                    },
                    BanAns = _services.GetListBanAn(),
                    KhachHangs = _services.GetListKH()
                };
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(PhieuDatBanVM vm)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");

            SavePhieuDatBanDTO p = new SavePhieuDatBanDTO
            {
                IdBanAn = vm.PhieuDatBan.IdBanAn,
                IdKhachHang = vm.PhieuDatBan.IdKhachHang,
                ThoiGianDat = vm.PhieuDatBan.ThoiGianDat,
                GhiChu = vm.PhieuDatBan.GhiChu
            };
            int i = _services.Add(p);

            if (i == -2)
            {
                ViewBag.MessagePhieuDatBan = "Khách hàng này không tồn tại";
                System.DateTime day = DateTime.Now;
                vm = new PhieuDatBanVM
                {
                    PhieuDatBan = new SavePhieuDatBanDTO
                    {
                        IdBanAn = vm.PhieuDatBan.IdBanAn,
                        IdKhachHang = p.IdKhachHang,
                        ThoiGianDat = Convert.ToDateTime(day),
                        GhiChu = vm.PhieuDatBan.GhiChu,
                    },
                    BanAns = _services.GetListBanAn(),
                    KhachHangs = _services.GetListKH()
                };
                return View(vm);
            }
            if (i == 0)
            {
                ViewBag.MessagePhieuDatBan = "Bàn này đã có người đặt";
                System.DateTime day = DateTime.Now;
                vm = new PhieuDatBanVM
                {
                    PhieuDatBan = new SavePhieuDatBanDTO
                    {
                        IdBanAn = vm.PhieuDatBan.IdBanAn,
                        IdKhachHang = p.IdKhachHang,
                        ThoiGianDat = Convert.ToDateTime(day),
                        GhiChu = vm.PhieuDatBan.GhiChu,
                    },
                    BanAns = _services.GetListBanAn(),
                    KhachHangs = _services.GetListKH()
                };
                return View(vm);
            }
            else if (i == -1)
            {
                ViewBag.MessagePhieuDatBan = "Bàn này đang được phục vụ";
                System.DateTime day = DateTime.Now;
                vm = new PhieuDatBanVM
                {
                    PhieuDatBan = new SavePhieuDatBanDTO
                    {
                        IdBanAn = vm.PhieuDatBan.IdBanAn,
                        IdKhachHang = p.IdKhachHang,
                        ThoiGianDat = Convert.ToDateTime(day),
                        GhiChu = vm.PhieuDatBan.GhiChu,
                    },
                    BanAns = _services.GetListBanAn(),
                    KhachHangs = _services.GetListKH()
                };
                return View(vm);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? Id)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (Id == null)
                return RedirectToAction("Index");
            PhieuDatBanDTO pDTO = _services.GetById(Id.Value);
            if (pDTO == null)
                return RedirectToAction("Index");
            SavePhieuDatBanDTO savePhieuDatBanDTO = _mapper.Map<PhieuDatBanDTO, SavePhieuDatBanDTO>(pDTO);
            KhachHang kh = _services.GetKhachHang(savePhieuDatBanDTO.IdKhachHang);
            ViewBag.TenKhachHang = kh.Ten;
            return View(savePhieuDatBanDTO);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Deleted(int? Id)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (Id == null)
                return RedirectToAction("Index");

            _services.Delete(Id.Value);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (KiemTraDangNhap() == false)
                return View("../Login/Index");
            if (id == null)
                return RedirectToAction("Index");
            PhieuDatBanDTO pDTO = _services.GetById(id.Value);

            if (pDTO == null)
                return RedirectToAction("Index");
            KhachHang kh = _services.GetKhachHang(pDTO.IdKhachHang);
            ViewBag.TenKhachHang = kh.Ten;
            return View(pDTO);
        }
    }
}