using BookRankings.DataAcess.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BookRankings.DataAccess
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly BooksDbContext context;
        private DbSet<T> dbSet;
        public EFRepository(BooksDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public T Get(Guid id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public void Remove(Guid id)
        {
            dbSet.Remove(Get(id));
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
            context.SaveChanges();
        }
    }
}
