using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specification
{
    public class HoaDonSpecification : Specification<HoaDon>
    {
        public HoaDonSpecification(int idBanAn, string trangThai) : base(MakeCriteria(idBanAn, trangThai))
        {

        }

        public HoaDonSpecification(int idBanAn, string trangThai, int pageIndex, int pageSize) : this(idBanAn, trangThai)
        {
            ApplyPaging(pageIndex, pageSize);
        }

        private static Expression<Func<HoaDon, bool>> MakeCriteria(int idBanAn, string trangThai)
        {
            Expression<Func<HoaDon, bool>> predicate = s => true;
            if (String.IsNullOrEmpty(trangThai))
            {
                trangThai = "";
            }
            if (!String.IsNullOrEmpty(trangThai))
            {
                predicate = s => s.TrangThai.ToLower().Contains(trangThai.ToLower()) || s.TrangThai.ToUpper().Contains(trangThai.ToUpper());
            }
            if (!idBanAn.Equals(0))
            {
                predicate = s => (s.TrangThai.ToLower().Contains(trangThai.ToLower()) || s.TrangThai.ToUpper().Contains(trangThai.ToUpper())) && s.IdBanAn.Equals(idBanAn);
            }
            return predicate;
        }
    }
}