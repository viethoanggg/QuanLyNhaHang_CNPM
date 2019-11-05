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
    }
}