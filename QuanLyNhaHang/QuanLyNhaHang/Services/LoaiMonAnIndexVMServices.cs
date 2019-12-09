using System.Linq;
using System;
using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.ViewModels;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Services.Interfaces;

namespace QuanLyNhaHang.Services
{
    public class LoaiMonAnIndexVMServices : ILoaiMonAnIndexVMServices
    {
        private readonly ILoaiMonAnServices _services;
        private readonly int pageSize = 10;

        public LoaiMonAnIndexVMServices(ILoaiMonAnServices services)
        {
            _services = services;
        }
        public LoaiMonAnVM GetLoaiMonAnVM(string currentSort, string searchString, int pageIndex)
        {
            int count = 0;
            IEnumerable<LoaiMonAnDTO> loaiMonAnDTOs = _services.GetListLoaiMonAn(searchString, pageIndex, pageSize, out count);
            
            switch (currentSort)
            {
                case "TEN_ASC":
                    loaiMonAnDTOs = loaiMonAnDTOs.OrderBy(s => s.Ten);
                    break;
                case "TEN_DESC":
                    loaiMonAnDTOs = loaiMonAnDTOs.OrderByDescending(s => s.Ten);
                    break;
            }

            return new LoaiMonAnVM
            {
                LoaiMonAns = new PaginatedList<LoaiMonAnDTO>(loaiMonAnDTOs, pageIndex, pageSize, count)
            };
        }

    }
}