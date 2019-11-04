using System;
using System.Collections.Generic;
using ApplicationCore.Entitites;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Services;

namespace QuanLyNhaHang.ViewModels
{
    public class ServeVM
    {
        public HoaDon HoaDon{ get; set; }
        public BanAn BanAn{ get; set; }
        public PaginatedList<ThucDon> ThucDons{ get; set; }
        public IEnumerable<LoaiMonAn> LoaiMonAns{ get; set; }
        public IEnumerable<CTHDMD> ChiTietHoaDons { get; set; }
    }
}