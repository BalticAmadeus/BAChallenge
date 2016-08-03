using BAChallengeWebServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BAChallengeWebServices.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("ApplicationContext")
        {
            Database.SetInitializer(new ApplicationDBInitializer());
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Result> Results { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}