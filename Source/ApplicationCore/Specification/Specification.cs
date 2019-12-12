using System;
using System.Linq.Expressions;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Specification
{
    public class Specification<T> : ISpecification<T>
    {
        public Specification(Expression<Func<T, bool>> criteria)
        {
            this.Criteria = criteria;
        }
        protected void ApplyPaging(int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.IsPaginated = true;
        }
        public Expression<Func<T, bool>> Criteria { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public bool IsPaginated { get; private set; }


    }
}