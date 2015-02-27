using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordCase.Core.Database.Interfaces;

namespace RecordCase.TestsCommon
{
    public class FakeUnitOfWork:  IUnitOfWork
    {
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new FakeRepository<TEntity>();
        }

        public void Dispose()
        {
            
        }
    }
}
