using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InventoryTransactions.Core.Contracts.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        T Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate);
        T Update(T entity);

        T Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(T entiry);
        void RemovRange(IEnumerable<T> entities);
    }
}
