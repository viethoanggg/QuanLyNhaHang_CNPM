using System;
using System.Linq;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.ModelsContainData.ViewModels;
using ApplicationCore.Services;
using QuanLyNhaHang.Services.Interfaces;

namespace QuanLyNhaHang.Services
{
    public class ThucDonIndexVMServices : IThucDonIndexVMServices
    {
        private readonly IThucDonServices _services;
        private readonly int pageSize = 10;

        public ThucDonIndexVMServices(IThucDonServices services)
        {
            _services = services;
        }

        public ThucDonVM GetThucDonVM(string searchString, string searchStringGiaTu, string searchStringGiaDen, string currentSort, int pageIndex)
        {

            int count;
            int giaTu = 0, giaDen = 0;
            if (!String.IsNullOrEmpty(searchStringGiaTu))
                giaTu = Convert.ToInt32(searchStringGiaTu);
            if (!String.IsNullOrEmpty(searchStringGiaDen))
                giaDen = Convert.ToInt32(searchStringGiaDen);

            var listThucDonMD = _services.GetListThucDonMD(searchString, giaTu,giaDen,pageIndex, pageSize, out count);
            switch (currentSort)
            {
                case "TenMonAn_ASC":
                    listThucDonMD = listThucDonMD.OrderBy(s => s.Ten);
                    break;
                case "TenMonAn_DESC":
                    listThucDonMD = listThucDonMD.OrderByDescending(s => s.Ten);
                    break;
                case "TenLoaiMonAn_ASC":
                    listThucDonMD = listThucDonMD.OrderBy(s => s.TenLoaiMonAn);
                    break;
                case "TenLoaiMonAn_DESC":
                    listThucDonMD = listThucDonMD.OrderByDescending(s => s.TenLoaiMonAn);
                    break;
                case "Gia_ASC":
                    listThucDonMD = listThucDonMD.OrderBy(s => s.Gia);
                    break;
                case "Gia_DESC":
                    listThucDonMD = listThucDonMD.OrderByDescending(s => s.Gia);
                    break;
            }
            return new ThucDonVM
            {
                ThucDonsMD = new PaginatedList<ThucDonMD>(listThucDonMD, pageIndex, pageSize, count)
            };
        }
    }
}