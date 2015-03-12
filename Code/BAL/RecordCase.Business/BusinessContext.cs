using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using LinqKit;
using RecordCase.Business.Entities;
using RecordCase.Business.FileFormatParsers;
using RecordCase.Common.Exceptions;
using RecordCase.Core.Collections.Extensions;
using RecordCase.Core.Database.Interfaces;
using RecordCase.Core.Filesystem;
using RecordCase.Core.System;
using RecordCase.Core.Validation;
using RecordCase.Model.Entities;
using RecordCase.Model.Entities.Locations;

namespace RecordCase.Business
{
    /// <summary>
    /// Encapsulates business rules when accessing the data layer.
    /// </summary>
    public partial class BusinessContext : IBusinessContext
    {
        private bool disposed;
        public IValidationRulesEngine ValidationRulesEngine { get; set; }

        public FileFormatParserProvider FileFormatParserProvider { get; set; }

        public IUnitOfWork UnitOfWork { get; set; }

        private T InvokeUpdateOrInsert<T>(Func<IRepository<T>, Func<T,T>> func, T ent)
            where T : class
        {
            try
            {
                if (ValidationRulesEngine!=null)
                    ValidationRulesEngine.ValidateOrThrow(ent);
                var rep = UnitOfWork.GetRepository<T>();
                return func(rep)(ent);
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();


                ex.EntityValidationErrors.ForEachInEnumerable(failure =>
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                });
                
                // Add the original exception as the innerException
                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb, ex);
            }
        }

        public BusinessContext(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            ValidationRulesEngine = new ValidationRulesEngine();
            ValidationRulesEngine.AddValidation(PredicateBuilder.True<Location>().And(l => l.ParentLocation!=null), "Location must have parent.");

            FileFormatParserProvider = new FileFormatParserProvider();
            FileFormatParserProvider.Add(MediaFormatExtension.Mp3, new FileFormatParserMp3());

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

        private IEnumerable<T> GetEntities<T>(Expression<Func<T, bool>> predicate) where T:class
        {
            return UnitOfWork.GetRepository<T>().Find(predicate);
        }

        private IEnumerable<T> GetEntities<T>() where T : class
        {
            return GetEntities<T>(null);
        }

        private Location AddLocationsIfDontExistFromFilepath(string filePath)
        {
            var tree = filePath.Split(new char[] { '\\' });
            var logicalDriveLetter = tree.First();

            //Computer Location
            var computerLocation = AddLocationToContextIfNotExists(new LocationComputer()
            {
                UniqueName = ComputerManager.ComputerSystem.Name,
                ParentLocation = RootLocation,
                Manufacturer = ComputerManager.ComputerSystem.Manufacturer,
                Model = ComputerManager.ComputerSystem.Model
            });

            var driveLetterLocation = AddLocationToContextIfNotExists(new LocationDriveLetter()
            {
                UniqueName = logicalDriveLetter,
                ParentLocation = computerLocation
            });

            //Folders
            //InsertRootFolder
            var parentLocation = AddLocationToContextIfNotExists(new LocationFolder()
            {
                UniqueName = "\\",
                ParentLocation = driveLetterLocation
            });

            //Insert Folders
            for (int i = 1; i < tree.Length - 1; i++)
            {
                parentLocation = AddLocationToContextIfNotExists(new LocationFolder()
                {
                    UniqueName = "\\" + tree[i],
                    ParentLocation = parentLocation
                });
            }

            return parentLocation;
        }

        public void ImportMusicTrack(FileInfo fileInfo)
        {
            Debug.WriteLine(fileInfo.FullName);
            //Location
            var location = AddLocationsIfDontExistFromFilepath(fileInfo.FullName);                        

            var musicTrackInstance = FileFormatParserProvider
                .GetParser(fileInfo.Extension)
                .GetMusicTrackInstanceFile(fileInfo, location);

            AddMusicTrackInstanceIfNotExists(musicTrackInstance);
            
        }

        public void ImportMusicTracks(string directoryPath, bool traverse)
        {
            //Import from current folder
            DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);
            dirInfo.GetFilesFromDirectory(traverse, "*.mp3").ForEach(f => ImportMusicTrack(f));
            UnitOfWork.Context.SaveChanges();
        }
        
    }
}