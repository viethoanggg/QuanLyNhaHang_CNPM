using System;
using System.Linq.Expressions;
using ApplicationCore.Entitites;
using ApplicationCore.Interfaces;
using QuanLyNhaHang.Services.Interfaces;
using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Services
{
    public class KhachHangServices:IKhachHangServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int pageSize = 10;
        public KhachHangServices(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public KhachHangVM GetKhachHangVM(int pageIndex = 1)
        {
            Expression<Func<KhachHang, bool>> predicate = m => true;
            var khachHangs = _unitOfWork.KhachHangs.Find(predicate);
            return new KhachHangVM
            {
                KhachHangs = PaginatedList<KhachHang>.Create(khachHangs, pageIndex, pageSize)
            }; 
            }
            public KhachHang GetKhachHang(int id)
            {
                KhachHang khachHang = _unitOfWork.KhachHangs.GetById(id);
                if (khachHang == null)
                {
                    return null;
                }
                return khachHang;
            }
            public void Edit(KhachHang khachHang)
            {
            _unitOfWork.KhachHangs.Update(khachHang);
            _unitOfWork.Complete();
            }
            public void Delete(int id)
            {
            KhachHang khachHang = GetKhachHang(id);
            _unitOfWork.KhachHangs.Remove(khachHang);
            _unitOfWork.Complete();
            }
            public void Create(KhachHang khachHang)
            {
            _unitOfWork.KhachHangs.Add(khachHang);
            _unitOfWork.Complete();
        }

    }
}