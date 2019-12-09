using ApplicationCore.Interfaces.IServices;
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
        public IActionResult Index(int pageIndex = 1)
        {
            return View(_servicesIndexVM.GetThongKeVM(pageIndex));
        }
    }
}