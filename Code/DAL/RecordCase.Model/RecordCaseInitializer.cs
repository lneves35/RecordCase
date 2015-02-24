using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordCase.Model.Entities;
using RecordCase.Model.Entities.Types;

namespace RecordCase.Model
{
    public class RecordCaseInitializer : CreateDatabaseIfNotExists<RecordCaseContext>
    {
        protected override void Seed(RecordCaseContext context)
        {
            List<Genre> defaultGenres = new List<Genre>();
            defaultGenres.Add(new Genre() {Name = "Disco"});
            defaultGenres.Add(new Genre() { Name = "House" });
            defaultGenres.Add(new Genre() { Name = "Techno" });
            defaultGenres.ForEach(g=>context.Genres.Add(g));


            List<Inches> defaultInches = new List<Inches>();
            defaultInches.Add(new Inches() { Name = "7''" });
            defaultInches.Add(new Inches() { Name = "10''" });
            defaultInches.Add(new Inches() { Name = "12''" });
            defaultInches.ForEach(i => context.Inches.Add(i));
            
            base.Seed(context);
        }
    }
}
