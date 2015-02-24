﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecordCase.Model.Entities
{
    public enum LocationType
    {
        Virtual,
        Physical
    }

    public class Location
    {
        public int LocationId { get; set; }
        
        [Required]
        public String Name { get; set; }

        [Required]
        public LocationType? LocationType { get; set; }

        [ForeignKey("ParentLocation")]
        public int? ParentLocationId { get; set; }

        public Location ParentLocation { get; set; }
        public ICollection<Location> ChildLocations { get; set; }

        

    }
}
