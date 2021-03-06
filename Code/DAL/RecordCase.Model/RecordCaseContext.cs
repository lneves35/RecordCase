﻿using System.Data.Entity;
using RecordCase.Model.Entities;
using RecordCase.Model.Entities.Types;
using RecordCase.Model.Interfaces;

namespace RecordCase.Model
{
    public class RecordCaseContext : DbContext
    {
        public RecordCaseContext(string connectionString, ISeeder seeder)
            : base(connectionString)
        {            
            Database.SetInitializer(new RecordCaseInitializer<RecordCaseContext>(seeder));             
        }

        protected RecordCaseContext(string connectionString)
            : base(connectionString)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

                       
        }
        

        public DbSet<MusicTrack> MusicTracks { get; set; }
        public DbSet<MusicTrackInstance> MusicTrackInstances { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Inches> Inches { get; set; }
    }
}
