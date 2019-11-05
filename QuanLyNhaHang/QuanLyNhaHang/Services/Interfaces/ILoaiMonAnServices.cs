using System.Collections.Generic;
using ApplicationCore.Entitites;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.ViewModels;
namespace QuanLyNhaHang.Services.Interfaces
{
    public interface ILoaiMonAnServices
    {
        LoaiMonAnVM GetLoaiMonAnVM(int pageIndex);
    }
}