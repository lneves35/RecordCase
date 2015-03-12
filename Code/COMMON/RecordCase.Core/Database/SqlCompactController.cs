using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using RecordCase.Common.Exceptions;
using RecordCase.Core.Database.Interfaces;
using RecordCase.Core.Properties;

namespace RecordCase.Core.Database
{
    public class SqlCompactController: ISqlCompactController
    {
        public string CreateDb(string filename)
        {
            return CreateDb(filename, null);
        }

        public string CreateDb(string filename, string password)
        {
            var file = new FileInfo(filename);
            
            if (File.Exists(filename))
                throw new RecordCaseDatabaseException(String.Format(Errors.ERR_DATABASE_001, filename));
            
            file.Directory.Create();

            var builder = new SqlCeConnectionStringBuilder()
            {
                Password = password ?? string.Empty,
                DataSource = filename,                
            };


            var engine = new SqlCeEngine(builder.ConnectionString);
            engine.CreateDatabase();
            return builder.ConnectionString;
        }
        
        public void DeleteDb(string filename)
        {
            if (!File.Exists(filename))
                throw new RecordCaseDatabaseException(String.Format(Errors.ERR_DATABASE_002, filename));
            File.Delete(filename);
        }
    }
}
