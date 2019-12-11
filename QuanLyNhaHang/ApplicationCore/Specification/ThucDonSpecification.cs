using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specification
{
    public class ThucDonSpecification : Specification<ThucDon>
    {
        public ThucDonSpecification(string tenMonAn, int giaTu, int giaDen) : base(MakeCriteria(tenMonAn, giaTu, giaDen))
        {

        }

        public ThucDonSpecification(string tenMonAn, int giaTu, int giaDen, int pageIndex, int pageSize) : this(tenMonAn, giaTu, giaDen)
        {
            ApplyPaging(pageIndex, pageSize);
        }

        private static Expression<Func<ThucDon, bool>> MakeCriteria(string tenMonAn, int giaTu, int giaDen)
        {
            Expression<Func<ThucDon, bool>> predicate = s => true;

            if (String.IsNullOrEmpty(tenMonAn))
                tenMonAn = "";
            else
            {
                predicate = s => s.Ten.ToLower().Contains(tenMonAn.ToLower());
            }
            if (giaTu > 0)
            {
                predicate = s => s.Ten.ToLower().Contains(tenMonAn.ToLower()) && s.Gia >= giaTu;
            }
            if (giaDen != 0)
            {
                predicate = s => s.Ten.ToLower().Contains(tenMonAn.ToLower()) && s.Gia >= giaTu && s.Gia <= giaDen;
            }

            return predicate;
        }
        public static Expression<Func<ThucDon, bool>> NoiExpression(Expression<Func<ThucDon, bool>> exp1, Expression<Func<ThucDon, bool>> exp2)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(ThucDon), "t");
            Expression body = Expression.AndAlso(exp1.Body, exp2.Body);
            var newlambda = Expression.Lambda<Func<ThucDon, bool>>(body, parameter);
            return newlambda;
        }
    }
}