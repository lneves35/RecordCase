using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using RecordCase.Core.Database.Interfaces;
using RecordCase.Core.Exceptions;
using RecordCase.Model.Entities;
using RecordCase.Model.Entities.Types;

namespace RecordCase.Business
{
    /// <summary>
    /// Encapsulates business rules when accessing the data layer.
    /// </summary>
    public class BusinessContext : IBusinessContext
    {
        public T InvokeRepositoryUpdate<T>(Func<IRepository<T>, T> func)
            where T : class
        {
            try
            {
                var rep = UnitOfWork.GetRepository<T>();
                return func(rep);
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                // Add the original exception as the innerException
                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb, ex);
            }
            catch (Exception e)
            {
                throw new RecordCaseException("msg", e);
            }
        }

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


        public void AddLocation(Location location)
        {
            //Do some validation (except for integrity restrictions)

            //Add to database
            InvokeRepositoryUpdate<Location>(rep => rep.Add(location));
        }
    }
}