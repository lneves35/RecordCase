using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordCase.Core.Database.Interfaces
{
    public interface IRemoteRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        TEntity Update(TEntity entity);
    }
}
