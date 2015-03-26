using System;
using System.Collections.Generic;
using System.Linq;
using LinqKit;
using RecordCase.Core.System;
using RecordCase.Model.Entities;
using RecordCase.Model.Entities.Locations;

namespace RecordCase.Business
{
    public partial class BusinessContext
    {
        private Location rootLocation;
        public Location RootLocation
        {

            get
            {
                if (rootLocation == null)
                {
                    var predicate = PredicateBuilder.True<Location>();
                    predicate.And(l => l.LocationId == 1);
                    rootLocation = GetEntities(predicate).Single();
                }
                return rootLocation;
            }
        }

        private T GetLocationFromContext<T>(string name, Location parent) where T : Location
        {
            var predicate = PredicateBuilder.True<T>();
            predicate = predicate.And(l => l.UniqueName.Equals(name, StringComparison.OrdinalIgnoreCase) && l.ParentLocation == parent);
            return GetEntities(predicate).SingleOrDefault();
        }

        public T AddLocationToContext<T>(T location) where T:Location
        {
            //Add to database
            return InvokeUpdateOrInsert(rep => rep.Add, location);
        }

        private T AddLocationToContextIfNotExists<T>(T l) where T : Location
        {
            //Check if location exists
            var location = GetLocationFromContext<T>(
                l.UniqueName,
                l.ParentLocation
                );

            if (location != null)
                return location;

            return AddLocationToContext(l);
        }

        
    }
}
