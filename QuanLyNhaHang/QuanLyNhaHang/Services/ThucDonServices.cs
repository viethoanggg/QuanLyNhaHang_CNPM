using System.Linq;
using System;
using System.Linq.Expressions;
using ApplicationCore.Entitites;
using ApplicationCore.Interfaces;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyNhaHang.Services
{
    public class ThucDonServices : IThucDonServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int pageSize = 3;
        public ThucDonServices(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }
        public ThucDonVM GetThucDonVM(string sort, string searchString, string currentFilter, string tenLoaiMonAn, int pageIndex = 1)
        {
            Expression<Func<ThucDon, bool>> predicate = m => true;
            if (!String.IsNullOrEmpty(searchString))
            {
                predicate = m => m.Ten.ToLower().Contains(searchString.ToLower());
            }

            var thucDons = _unitOfWork.ThucDons.Find(predicate);

            if (!String.IsNullOrEmpty(tenLoaiMonAn))
            {
                thucDons = _unitOfWork.ThucDons.GetClassifiedFoods(thucDons, tenLoaiMonAn);
            }
           
            var Loai = _unitOfWork.ThucDons.GetLoaiThucAns();
            var listThucDonMD = from s in thucDons
                                join t in Loai
                                 on s.IdLoaiMonAn equals t.Id
                                select new ThucDonMD
                                {
                                    Id = s.Id,
                                    TenLoaiMonAn = t.Ten,
                                    Ten = s.Ten,
                                    Gia = s.Gia
                                };
            return new ThucDonVM
            {
                ThucDonsMD = PaginatedList<ThucDonMD>.Create(listThucDonMD, pageIndex, pageSize)
            };
        }

        public IEnumerable<LoaiMonAn> GetLoaiMonAns()
        {
            IEnumerable<LoaiMonAn> loaiL = _unitOfWork.ThucDons.GetLoaiThucAns();
            return loaiL;
        }
        public void Create(ThucDon td)
        {
            _unitOfWork.ThucDons.Add(td);
            _unitOfWork.Complete();          
        }
        public ThucDon GetMonAn(int id)
        {
            return _unitOfWork.ThucDons.GetById(id);
        }
        public ThucDonMD GetMonAnMD(int id)
        {
            ThucDon monAn = _unitOfWork.ThucDons.GetById(id);
            IEnumerable<LoaiMonAn> listL = GetLoaiMonAns();
            IEnumerable<ThucDonMD> listMonAnMD = from s in listL
                                                 where s.Id == monAn.IdLoaiMonAn
                                                 select new ThucDonMD
                                                 {
                                                     Id = monAn.Id,
                                                     TenLoaiMonAn = s.Ten,
                                                     Ten = monAn.Ten,
                                                     Gia = monAn.Gia
                                                 };
            ThucDonMD monAnMD = listMonAnMD.Where(s => s.Id == monAn.Id).FirstOrDefault();

            return monAnMD;
        }
        public void Edit(ThucDon td)
        {
            _unitOfWork.ThucDons.Update(td);
            _unitOfWork.Complete();
            
        }
        public void ThemMonAn(ThucDon td)
        {
            _unitOfWork.ThucDons.Add(td);
            _unitOfWork.Complete();
        }
        public void Remove(ThucDon td)
        {
            _unitOfWork.ThucDons.Remove(td);
            _unitOfWork.Complete();
        }
    }
}