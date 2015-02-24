using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RecordCase.Core.Database.Interfaces;
using RecordCase.Model.Entities;
using RecordCase.Model.Entities.Types;

namespace RecordCase.Business
{
    /// <summary>
    /// Encapsulates business rules when accessing the data layer.
    /// </summary>
    public class BusinessContext : IBusinessContext
    {
        private bool disposed;

        public IUnitOfWork UnitOfWork { get; set; }

        public BusinessContext(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed || !disposing)
                return;

            if (UnitOfWork != null)
                UnitOfWork.Dispose();

            disposed = true;
        }

        #endregion

        private IEnumerable<Genre> GetGenres(Expression<Func<Genre, bool>> predicate)
        {
            return UnitOfWork.GetRepository<Genre>().Find(predicate);
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return GetGenres(null);
        }
    }
}