using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using RecordCase.Core.Database.Extensions;
using RecordCase.Core.Database.Interfaces;
using RecordCase.Model;
namespace RecordCase.Repository
{
    public class LocalRepository<TEntity> : BaseRepository<TEntity>, IRepository<TEntity> where TEntity : class
    {
        public LocalRepository(DbContext dbContext)
            : base(dbContext)
        {
            //Load All Entities To Local
            dbContext.LoadAllTables();     
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            predicate = predicate ?? PredicateBuilder.True<TEntity>();
            return EntitySet.Local.Where(predicate.Invoke);
        }

        public  TEntity Add(TEntity entity)
        {
            return EntitySet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            EntitySet.Remove(entity);
        }
    }
}
