using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordCase.Model;
using RecordCase.Model.Entities.Types;
using RecordCase.Model.Interfaces;

namespace RecordCase.Business
{
    /// <summary>
    /// Singleton
    /// </summary>
    public class RecordCaseContextSeeder: ISeeder
    {
        private static RecordCaseContextSeeder seeder;
        
        private RecordCaseContextSeeder(){}

        public static RecordCaseContextSeeder GetSeeder()
        {
            if (seeder==null)
                seeder = new RecordCaseContextSeeder();
            return seeder;
        }

        public void Seed(RecordCaseContext ctx)
        {
            List<Genre> defaultGenres = new List<Genre>();
            defaultGenres.Add(new Genre() { Name = "Disco" });
            defaultGenres.Add(new Genre() { Name = "House" });
            defaultGenres.Add(new Genre() { Name = "Techno" });
            defaultGenres.ForEach(g => ctx.Genres.Add(g));


            List<Inches> defaultInches = new List<Inches>();
            defaultInches.Add(new Inches() { Name = "7''" });
            defaultInches.Add(new Inches() { Name = "10''" });
            defaultInches.Add(new Inches() { Name = "12''" });
            defaultInches.ForEach(i => ctx.Inches.Add(i));
        }
    }
}
