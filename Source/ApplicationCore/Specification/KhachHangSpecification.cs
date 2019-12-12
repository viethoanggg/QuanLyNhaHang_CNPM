using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specification
{
    public class KhachHangSpecification : Specification<KhachHang>
    {
        public KhachHangSpecification(string Ten, string SDT, string DiaChi) : base(MakeCriteria(Ten, SDT, DiaChi))
        {

        }

        public KhachHangSpecification(string Ten, string SDT, string DiaChi, int pageIndex, int pageSize) : this(Ten, SDT, DiaChi)
        {
            ApplyPaging(pageIndex, pageSize);
        }

        private static Expression<Func<KhachHang, bool>> MakeCriteria(string Ten, string SDT, string DiaChi)
        {
            Expression<Func<KhachHang, bool>> predicate = s => true;
            if (String.IsNullOrEmpty(Ten))
                Ten = "";
            if (String.IsNullOrEmpty(SDT))
                SDT = "";
            if (String.IsNullOrEmpty(DiaChi))
                DiaChi = "";
            if (!String.IsNullOrEmpty(Ten))
            {
                predicate = s => s.Ten.ToLower().Contains(Ten.ToLower());
            }
            if (!String.IsNullOrEmpty(SDT))
            {
                predicate = s => s.Ten.ToLower().Contains(Ten.ToLower()) && s.SDT.ToLower().Contains(SDT.ToLower());
            }
            if (!String.IsNullOrEmpty(DiaChi))
            {
                predicate = s => s.Ten.ToLower().Contains(Ten.ToLower()) && s.SDT.ToLower().Contains(SDT.ToLower()) && s.DiaChi.ToLower().Contains(DiaChi.ToLower());
            }
            return predicate;
        }
    }
}