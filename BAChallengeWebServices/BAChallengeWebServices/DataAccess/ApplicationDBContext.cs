using BAChallengeWebServices.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BAChallengeWebServices.DataAccess
{
    /// <summary>
    /// Primary entity framework class, for accessing data objects.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("ApplicationContext")
        {
            Database.SetInitializer(new ApplicationDbInitializer());
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ExceptionModel> Exceptions { get; set; }
        public DbSet<ActivityParticipation> ActivityParticipations { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}