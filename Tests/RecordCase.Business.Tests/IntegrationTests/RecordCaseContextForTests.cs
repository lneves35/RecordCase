using System.Data.Entity;
using RecordCase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordCase.Model.Interfaces;

namespace RecordCase.Business.Tests.IntegrationTests
{
    /// <summary>
    /// This context forces model creation because of metadata caching in EF. 
    /// 
    /// </summary>
    public class RecordCaseContextForTests : RecordCaseContext
    {
        public RecordCaseContextForTests(string connectionString, ISeeder seeder) : base(connectionString)
        {
            Database.SetInitializer(new RecordCaseInitializer<RecordCaseContextForTests>(seeder));  
            Database.Initialize(force: true);
        }
    }
}
