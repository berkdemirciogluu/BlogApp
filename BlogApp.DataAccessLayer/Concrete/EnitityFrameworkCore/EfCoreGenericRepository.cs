
using BlogApp.DataAccessLayer.Abstract;
using BlogApp.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccessLayer.Concrete.EnitityFrameworkCore
{
    public class EfCoreGenericRepository<T,TContext> : IGenericRepository<T> 
        where T : class
        where TContext : DbContext, new()
    {
        public void Add(T entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(T entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<T>().ToList()
                    : context.Set<T>().Where(filter).ToList();
            }
        }
        public T GetById(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<T>().Find(id);
            }
        }
        public void Update(T entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
