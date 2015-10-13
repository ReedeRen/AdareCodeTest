using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AdareCode.Models;


namespace AdareCode.DAL
{
    public class AdareContext : DbContext
    {
        public AdareContext()
            : base("AdareConnectionStr")
        {
        }

        public DbSet<EventType> EventTypes { set; get; }
        public DbSet<AdareShow> AdareShows { set; get; }
        public DbSet<Client> Clients { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}