using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.Services;
using QuanLyNhaHang.Services.Interfaces;
using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Services
{
    public class BanAnIndexVMServices : IBanAnIndexVMServices
    {
        private readonly IBanAnServices _services;
        private readonly int pageSize = 10;
        public BanAnIndexVMServices(IBanAnServices services)
        {
            _services = services;
        }

        public BanAnVM GetBanAnVM(string trangThai, int pageIndex)
        {
            int count;
            IEnumerable<BanAnDTO> listBanAnDTO = _services.GetListBanAn(trangThai, pageIndex, pageSize, out count);
            return new BanAnVM
            {
                BanAns = new PaginatedList<BanAnDTO>(listBanAnDTO, pageIndex, pageSize, count)
            };
        }
    }
}