using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specification
{
    public class BanAnSpecification : Specification<BanAn>
    {
        public BanAnSpecification(string trangThai) : base(MakeCriteria(trangThai))
        {

        }

        public BanAnSpecification(string trangThai, int pageIndex, int pageSize) : this(trangThai)
        {
            ApplyPaging(pageIndex, pageSize);
        }

        private static Expression<Func<BanAn, bool>> MakeCriteria(string trangThai)
        {
            Expression<Func<BanAn, bool>> predicate = s => true;

            if (String.IsNullOrEmpty(trangThai) == false)
            {
                predicate = s => s.TrangThai == trangThai;
            }

            return predicate;
        }
    }


}