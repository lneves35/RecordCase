using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordCase.Core.Database.Interfaces;

namespace RecordCase.TestsCommon
{
    public class FakeRepository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        public TEntity Add(TEntity entity) { return null; }

        public void Remove(TEntity entity){}

        public TEntity Update(TEntity entity){ return null; }

        public IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate){ return null; }
    }
}
