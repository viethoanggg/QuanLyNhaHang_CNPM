using System;
using System.Linq.Expressions;
using ApplicationCore.Entitites;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Services
{
    public class BanAnServices : IBanAnServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int pageSize = 10;
        public BanAnServices(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public BanAnVM GetBanAnVM(int pageIndex = 1)
        {
            Expression<Func<BanAn, bool>> predicate = m => true;
            var banAns = _unitOfWork.BanAns.Find(predicate);
            return new BanAnVM
            {
                BanAns = PaginatedList<BanAn>.Create(banAns, pageIndex, pageSize)
            };
        }

        public BanAn GetBanAn(int id)
        {
            BanAn banAn = _unitOfWork.BanAns.GetById(id);
            if (banAn == null)
                return null;
            return banAn;
        }
        public void Edit(BanAn banAn)
        {
            _unitOfWork.BanAns.Update(banAn);
            _unitOfWork.Complete();
        }
        public void Delete(int id)
        {
            BanAn banAn = GetBanAn(id);
            _unitOfWork.BanAns.Remove(banAn);
            _unitOfWork.Complete();
        }
        public void Create(BanAn banAn)
        {
            if (banAn == null)
                return;
            _unitOfWork.BanAns.Add(banAn);
            _unitOfWork.Complete();
        }

        public HoaDon CreateBill(HoaDon hoaDon)
        {
            HoaDon hd = hoaDon;
            _unitOfWork.HoaDons.Add(hd);
            return hd;
        }
    }

}