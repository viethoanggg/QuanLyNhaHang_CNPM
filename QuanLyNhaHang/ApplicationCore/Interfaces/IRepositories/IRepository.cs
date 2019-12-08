using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IRepository<T> where T : IAggregateRoot
    {

        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> FindSpec(ISpecification<T> spec);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        int Count(ISpecification<T> spec);

    }
}
