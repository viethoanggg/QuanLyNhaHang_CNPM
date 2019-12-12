using System.Collections.Generic;
using System.Linq;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.Models;

using ApplicationCore.Services;
using QuanLyNhaHang.Services.Interfaces;
using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Services
{
    public class KhachHangIndexVMServices : IKhachHangIndexVMServices
    {
        private readonly IKhachHangServices _services;
        private readonly int pageSize = 10;
        public KhachHangIndexVMServices(IKhachHangServices services)
        {
            _services = services;
        }
        public KhachHangVM GetKhachHangVM(string currentSort, string Ten, string SDT, string DiaChi, int pageIndex)
        {
            int count;
            IEnumerable<KhachHangDTO> listKhachHang = _services.GetlistKhachHang(Ten, SDT, DiaChi, pageIndex, pageSize, out count);

            switch (currentSort)
            {
                case "Ten_ASC":
                    listKhachHang = listKhachHang.OrderBy(s => s.Ten);
                    break;
                case "Ten_DESC":
                    listKhachHang = listKhachHang.OrderByDescending(s => s.Ten);
                    break;
                case "SDT_ASC":
                    listKhachHang = listKhachHang.OrderBy(s => s.SDT);
                    break;
                case "SDT_DESC":
                    listKhachHang = listKhachHang.OrderByDescending(s => s.SDT);
                    break;
                case "DiaChi_ASC":
                    listKhachHang = listKhachHang.OrderBy(s => s.DiaChi);
                    break;
                case "DiaChi_DESC":
                    listKhachHang = listKhachHang.OrderByDescending(s => s.DiaChi);
                    break;

            }
            return new KhachHangVM
            {
                KhachHangs = new PaginatedList<KhachHangDTO>(listKhachHang, pageIndex, pageSize, count)
            };
        }
    }
}