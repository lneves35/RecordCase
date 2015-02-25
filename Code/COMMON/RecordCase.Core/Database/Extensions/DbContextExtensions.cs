using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

using System.Text;

namespace RecordCase.Core.Database.Extensions
{
    public static class DbContextExtensions
    {
        /// <summary>
        /// Loads all entities to context (You have been warned ^_^)
        /// </summary>
        /// <param name="dbContext"></param>
        public static void LoadAllTables(this DbContext dbContext)
        {
            //Get all DBSets
            var props = dbContext.GetType().GetProperties().Where(p => p.PropertyType.IsGenericType
                                                           &&
                                                           p.PropertyType.GetGenericTypeDefinition() == typeof (DbSet<>));
            //For each DBSet invoke Load()
            foreach (var propertyInfo in props)
            {
                var loadMethod = typeof(QueryableExtensions).GetMethod("Load");
                var obj = propertyInfo.GetValue(dbContext);
                loadMethod.Invoke(null, new object[] { obj });
            }

        }
    }
}
