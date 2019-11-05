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
        LoaiMonAn GetLoaiMonAn(int id);
        void Edit(LoaiMonAn loaiMonAn);
        void Delete(int id);
        void Create(LoaiMonAn loaiMonAn);
    }
}