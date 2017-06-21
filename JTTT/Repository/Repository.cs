using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using JTTT.Interfaces;

namespace JTTT.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IDBEntity
    {
        public int Add(T entity)
        {
            using (var context = new JtttContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
                return entity.Id;
            }
        }

        public void Update(T entity)
        {
            using (var context = new JtttContext())
            {
                context.Set<T>().Attach(entity);
                context.Entry<T>(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new JtttContext())
            {
                context.Set<T>().Attach(entity);
                context.Entry<T>(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new JtttContext())
            {
                var entity = context.Set<T>().First(x => x.Id == id);
                context.Set<T>().Attach(entity);
                context.Entry<T>(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public T FindById(int id, params Expression<Func<T, object>>[] includeItems)
        {
            using (var context = new JtttContext())
            {
                var result = context.Set<T>() as IQueryable<T>;
                foreach (var include in includeItems)
                {
                    result = result.Include(include);
                }
                return result.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<T> Find(Func<T, bool> filter, params Expression<Func<T, object>>[] includeItems)
        {
            using (var context = new JtttContext())
            {
                var result = context.Set<T>() as IQueryable<T>;
                foreach (var include in includeItems)
                {
                    result = result.Include(include);
                }
                return result.Where(filter).ToList();
            }
        }

        public bool Any(Func<T, bool> filter, params Expression<Func<T, object>>[] includeItems)
        {
            using (var context = new JtttContext())
            {
                var result = context.Set<T>() as IQueryable<T>;
                foreach (var include in includeItems)
                {
                    result = result.Include(include);
                }
                return result.Where(filter).Any();
            }
        }


        public List<T> FindAll(params Expression<Func<T, object>>[] includeItems)
        {
            using (var context = new JtttContext())
            {
                var result = context.Set<T>() as IQueryable<T>;
                foreach (var include in includeItems)
                {
                    result = result.Include(include);
                }
                return result.ToList();
            }
        }
    }
}
