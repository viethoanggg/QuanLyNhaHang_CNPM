using System;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Services.Interfaces;

namespace QuanLyNhaHang.Controllers
{
    public class ThongKeController : Controller
    {
        private readonly IThongKeServices _services;
        private readonly IThongKeIndexVMServices _servicesIndexVM;
        public ThongKeController(IThongKeServices services, IThongKeIndexVMServices servicesIndexVM)
        {
            this._services = services;
            this._servicesIndexVM = servicesIndexVM;
        }
        public IActionResult Index(ThongKeVM vm,int pageIndex = 1)
        {
            DateTime thoiGianTu = vm.ThoiGianTu;
            DateTime thoiGianDen = vm.ThoiGianDen;
            return View(_servicesIndexVM.GetThongKeVM(pageIndex));
        }
    }
}