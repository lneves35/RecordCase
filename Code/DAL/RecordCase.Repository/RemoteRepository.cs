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
    public class RemoteRepository<TEntity> : BaseRepository<TEntity> 
        where TEntity : class
    {
        public RemoteRepository(RecordCaseContext dbContext) : base(dbContext){}
        
        #region IRepository<TEntity> Members
        
        override public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            predicate = predicate ?? PredicateBuilder.True<TEntity>();
            return EntitySet.AsExpandable().Where(predicate);
        }

        #endregion
    }
}
