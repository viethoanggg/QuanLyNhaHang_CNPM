using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.Entitites;
using ApplicationCore.Interfaces;
using QuanLyNhaHang.Services.Interfaces;

namespace QuanLyNhaHang.Services
{
    public class HoaDonServices : IHoaDonServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public HoaDonServices(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public readonly int pageSize = 5;
        public PaginatedList<HoaDon> GetHoaDonVM(int pageIndex)
        {
            Expression<Func<HoaDon, bool>> predicate = s => true;
            IEnumerable<HoaDon> hoaDons = _unitOfWork.HoaDons.GetAll();
            return PaginatedList<HoaDon>.Create(hoaDons, pageIndex, pageSize);
        }
        public void Delete(HoaDon HoaDon)
        {
            _unitOfWork.HoaDons.Remove(HoaDon);
            _unitOfWork.Complete();
        }

        public HoaDon FindHD(int id)
        {
            HoaDon hoaDon = _unitOfWork.HoaDons.GetById(id);
            if(hoaDon==null)
                return null;
            return hoaDon;
        }

        public BanAn FindBanAn(int IdHoaDon)
        {
            BanAn ba = _unitOfWork.HoaDons.FindBanAn(IdHoaDon);
            return ba;
        }
    }
}