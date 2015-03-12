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
    public abstract class BaseRepository<TEntity>
        where TEntity : class
    {
        protected DbContext DbContext { get; set; }

        protected DbSet<TEntity> EntitySet { get; set; }

        protected BaseRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            EntitySet = dbContext.Set<TEntity>();
        }
    }
}
