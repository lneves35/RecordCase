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
    public class LocalRepository<TEntity> : BaseRepository<TEntity>, IRepository<TEntity> 
        where TEntity : class
    {
        public LocalRepository(RecordCaseContext dbContext) : base(dbContext)
        {
            //Load All Entities To Local
            dbContext.LoadAllTables();            
        }

        override public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            predicate = predicate ?? PredicateBuilder.True<TEntity>();
            return EntitySet.Local.Where(predicate.Invoke);
        }
    }
}
