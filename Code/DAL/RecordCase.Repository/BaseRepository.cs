using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordCase.Model;
using RecordCase.Core.Database.Interfaces;

namespace RecordCase.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected RecordCaseContext DbContext { get; set; }

        protected DbSet<TEntity> EntitySet { get; set; }

        protected BaseRepository(RecordCaseContext dbContext)
        {
            DbContext = dbContext;
            EntitySet = DbContext.Set<TEntity>();
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
        
        public abstract IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);

    }
}
