using BookRankings.DataAcess.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BookRankings.BusinessLogic
{
    public class Service<T> where T:class
    {
        private readonly IRepository<T> repository;

        public Service(IRepository<T> repository)
        {
            this.repository = repository;
        }
        public void Add(T entity)
        {
            repository.Add(entity);
        }

        public T Get(Guid id)
        {
            return repository.Get(id);
        }

        public void Update(T entity)
        {
            repository.Update(entity);
        }
        public void Remove(Guid id)
        {
            repository.Remove(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
           return  repository.GetAll(filter, orderBy, includeProperties);
        }

    }
}
