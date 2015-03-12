using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordCase.Core.System;
using RecordCase.Model;
using RecordCase.Model.Entities;
using RecordCase.Model.Entities.Locations;
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
            var defaultGenres = new List<Genre>();
            defaultGenres.Add(new Genre() { Name = "Disco" });
            defaultGenres.Add(new Genre() { Name = "House" });
            defaultGenres.Add(new Genre() { Name = "Techno" });
            defaultGenres.ForEach(g => ctx.Genres.Add(g));


            var defaultInches = new List<Inches>();
            defaultInches.Add(new Inches() { Name = "7''" });
            defaultInches.Add(new Inches() { Name = "10''" });
            defaultInches.Add(new Inches() { Name = "12''" });
            defaultInches.ForEach(i => ctx.Inches.Add(i));

            var defaultLocations = new List<Location>();
            var rootLocation = new Location() {UniqueName = "Record Case"};
            defaultLocations.Add(rootLocation);
            defaultLocations.ForEach(i => ctx.Locations.Add(i));
        }
    }
}
