using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BookRankings.DataAcess.Abstractions
{
    public interface IRepository<T> where T:class
    {
        T Get(Guid id);
        void Add(T entity);
        void Remove(Guid id);
        void Update(T entity);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null, string includeProperties = null);
    }
}
