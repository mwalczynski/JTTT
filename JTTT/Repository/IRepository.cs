using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JTTT.Interfaces;

namespace JTTT.Repository
{
    public interface IRepository<T> where T : class, IDBEntity
    {
        int Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T FindById(int id, params Expression<Func<T, object>>[] includeItems);
        List<T> Find(Func<T, bool> filter, params Expression<Func<T, object>>[] includeItems);
        bool Any(Func<T, bool> filter, params Expression<Func<T, object>>[] includeItems);
        List<T> FindAll(params Expression<Func<T, object>>[] includeItems);
    }
}
