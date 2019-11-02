using System.Collections.Generic;
using ApplicationCore.Entitites;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Services
{
    public interface IThucDonServices
    {
        ThucDonVM GetThucDonVM(string sort, string searchString, string currentFilter, string tenLoaiMonAn, int pageIndex);
        IEnumerable<LoaiMonAn> GetLoaiMonAns();
        ThucDon GetMonAn(int id);
        ThucDonMD GetMonAnMD(int id);
        void Create(ThucDon td);
        void Edit(ThucDon td);
        void Remove(ThucDon td);
    }
}