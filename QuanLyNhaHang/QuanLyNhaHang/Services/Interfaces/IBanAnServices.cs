using System.Collections.Generic;
using ApplicationCore.Entitites;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Services
{
    public interface IBanAnServices
    {
        BanAnVM GetBanAnVM(int pageIndex);
        BanAn GetBanAn(int id);
        void Edit(BanAn banAn);
        void Delete(int id);
        void Create(BanAn banAn);
        HoaDon CreateBill(HoaDon hoaDon);
    }
}