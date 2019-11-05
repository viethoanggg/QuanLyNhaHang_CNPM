using System;
using System.Linq.Expressions;
using ApplicationCore.Entitites;
using ApplicationCore.Interfaces;
using QuanLyNhaHang.Services.Interfaces;
using QuanLyNhaHang.ViewModels;

namespace QuanLyNhaHang.Services
{
    public class LoaiMonAnServices : ILoaiMonAnServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int pageSize=10;
        public LoaiMonAnServices(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public LoaiMonAnVM GetLoaiMonAnVM(int pageIndex=1)
        {
            Expression<Func<LoaiMonAn, bool>> predicate = m => true;
            var loaiMonAns = _unitOfWork.LoaiMonAns.Find(predicate);
            return new LoaiMonAnVM
            {
                LoaiMonAns = PaginatedList<LoaiMonAn>.Create(loaiMonAns, pageIndex, pageSize)
            };
        }

        public LoaiMonAn GetLoaiMonAn(int id)
        {
            LoaiMonAn loaiMonAn = _unitOfWork.LoaiMonAns.GetById(id);
            if(loaiMonAn==null)
            {
                return null;
            }
            return loaiMonAn;
        }
        public void Edit(LoaiMonAn loaiMonAn)
        {
            _unitOfWork.LoaiMonAns.Update(loaiMonAn);
            _unitOfWork.Complete();
        }
        public void Delete(int id)
        {
            LoaiMonAn loaiMonAn = GetLoaiMonAn(id);
            _unitOfWork.LoaiMonAns.Remove(loaiMonAn);
            _unitOfWork.Complete();
        }
        public void Create(LoaiMonAn loaiMonAn)
        {
            if(loaiMonAn==null)
                return;
            _unitOfWork.LoaiMonAns.Add(loaiMonAn);
            _unitOfWork.Complete();
        }
    }
}