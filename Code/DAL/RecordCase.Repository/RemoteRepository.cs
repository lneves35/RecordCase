using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using RecordCase.Core.Database.Interfaces;
using RecordCase.Model;

namespace RecordCase.Repository
{
    public class RemoteRepository<TEntity> : 
        BaseRepository<TEntity>, 
        IRemoteRepository<TEntity> where TEntity : class
    {
        public RemoteRepository(DbContext dbContext) : base(dbContext){}
        
        #region IRepository<TEntity> Members
        
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            predicate = predicate ?? PredicateBuilder.True<TEntity>();
            return EntitySet.AsExpandable().Where(predicate);
        }

        public TEntity Add(TEntity entity)
        {
            var ret = EntitySet.Add(entity);
            DbContext.SaveChanges();
            return ret;
        }

        public void Remove(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                EntitySet.Attach(entity);
            }
            EntitySet.Remove(entity);
            DbContext.SaveChanges();
        }


        public TEntity Update(TEntity entity)
        {
            EntitySet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
            return entity;
        }
        #endregion
    }
}
