using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace RecordCase.Core.Database.Extensions
{
    public static class DbContextExtensions
    {
        public static void LoadAllTables(this DbContext dbContext)
        {
            var props = dbContext.GetType().GetProperties().Where(p => p.PropertyType.IsGenericType
                                                           &&
                                                           p.PropertyType.GetGenericTypeDefinition() == typeof (DbSet<>));


        }
    }
}
