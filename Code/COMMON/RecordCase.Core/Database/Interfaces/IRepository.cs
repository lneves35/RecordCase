using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RecordCase.Core.Database.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity entity);
        void Remove(TEntity entity);

        TEntity Update(TEntity entity);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
