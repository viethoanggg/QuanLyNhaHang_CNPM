using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specification
{
    public class NguoiDungSpecification : Specification<NguoiDung>
    {
        public NguoiDungSpecification(string Ten, string TenDangNhap, string VaiTro, int TrangThai) : base(MakeCriteria(Ten, TenDangNhap, VaiTro, TrangThai))
        {

        }

        public NguoiDungSpecification(string Ten, string TenDangNhap, string VaiTro, int TrangThai, int pageIndex, int pageSize) : this(Ten, TenDangNhap, VaiTro, TrangThai)
        {
            ApplyPaging(pageIndex, pageSize);
        }

        private static Expression<Func<NguoiDung, bool>> MakeCriteria(string Ten, string TenDangNhap, string VaiTro, int TrangThai)
        {
            Expression<Func<NguoiDung, bool>> predicate = s => true;
            if (String.IsNullOrEmpty(Ten))
                Ten = "";
            if (String.IsNullOrEmpty(TenDangNhap))
                TenDangNhap = "";
            if (String.IsNullOrEmpty(VaiTro))
                VaiTro = "";
            if (String.IsNullOrEmpty(VaiTro))
                VaiTro = "";
            if (!String.IsNullOrEmpty(Ten))
            {
                predicate = s => s.Ten.ToLower().Contains(Ten.ToLower());
            }
            if (!String.IsNullOrEmpty(TenDangNhap))
            {
                predicate = s => s.Ten.ToLower().Contains(Ten.ToLower()) && s.TenDangNhap.ToLower().Contains(TenDangNhap.ToLower());
            }
            if (!String.IsNullOrEmpty(VaiTro))
            {
                predicate = s => s.Ten.ToLower().Contains(Ten.ToLower()) && s.TenDangNhap.ToLower().Contains(TenDangNhap.ToLower()) && s.Role.ToLower().Contains(VaiTro.ToLower());
            }
            if (!TrangThai.Equals(0))
            {
                predicate = s => s.Ten.ToLower().Contains(Ten.ToLower()) && s.TenDangNhap.ToLower().Contains(TenDangNhap.ToLower()) && s.Role.ToLower().Contains(VaiTro.ToLower()) && s.TrangThai.Equals(TrangThai);
            }
            return predicate;
        }
    }
}