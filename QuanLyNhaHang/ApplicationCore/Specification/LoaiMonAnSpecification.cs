using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specification
{
    public class LoaiMonAnSpecification : Specification<LoaiMonAn>
    {
        public LoaiMonAnSpecification(string TenLoaiMonAn) : base(MakeCriteria(TenLoaiMonAn))
        {

        }
        public LoaiMonAnSpecification(string TenLoaiMonAn, int pageIndex, int pageSize) : this(TenLoaiMonAn)
        {
            ApplyPaging(pageIndex, pageSize);
        }
        public static Expression<Func<LoaiMonAn, bool>> MakeCriteria(string TenLoaiMonAn)
        {
            Expression<Func<LoaiMonAn, bool>> predicate = s => true;
            if (!String.IsNullOrEmpty(TenLoaiMonAn))
            {
                predicate = s => s.Ten.ToLower().Contains(TenLoaiMonAn.ToLower());
            }
            return predicate;
        }
    }
}