using System.Data.Entity;
using RecordCase.Model.Interfaces;

namespace RecordCase.Model
{
    public class RecordCaseInitializer<T> : CreateDatabaseIfNotExists<T> where T : RecordCaseContext
    {
        private ISeeder Seeder { get; set; }

        public RecordCaseInitializer(ISeeder seeder)
        {
            Seeder = seeder;
        }

        
        protected override void Seed(T context)
        {
            base.Seed(context);

            if (Seeder!=null)
                Seeder.Seed(context);            
        }
    }
}
