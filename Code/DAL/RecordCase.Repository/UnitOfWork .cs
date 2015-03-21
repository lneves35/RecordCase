using System;
using System.Collections.Generic;
using System.Data.Entity;
using RecordCase.Core.Database.Interfaces;
using RecordCase.Model;

namespace RecordCase.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly bool useLocalRepository;

        private bool disposed;
        
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public DbContext Context { get; set; }

        public UnitOfWork(DbContext context, bool useLocalRepository)
        {
            Context = context;
            this.useLocalRepository = useLocalRepository;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class 
        {
            IRepository<TEntity> repo;

            if (repositories.ContainsKey(typeof(TEntity)))
            {
                repo = repositories[typeof(TEntity)] as IRepository<TEntity>;
            }
            else
            {
                repo = useLocalRepository
                    ? new LocalRepository<TEntity>(Context) as IRepository<TEntity>
                    : new RemoteRepository<TEntity>(Context);
                repositories.Add(typeof(TEntity), repo);
            }
            return repo;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed || !disposing)
                return;

            if (Context != null)
                Context.Dispose();

            disposed = true;
        }

        
    }
}
