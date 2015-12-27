using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using Ultra.Core.Domain.Entities;

namespace Ultra.Core.Infrastructure.Data
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<CoreDbContext>(new MigrateDatabaseToLatestVersion<CoreDbContext, CoreDbConfiguration>());
        }

        //public virtual DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class CoreDbConfiguration : DbMigrationsConfiguration<CoreDbContext>
    {
        public CoreDbConfiguration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            
        }
    }

    public class MigrationsContextFactory : IDbContextFactory<CoreDbContext>
    {
        public CoreDbContext Create()
        {
            return IoC.Resolve<CoreDbContext>();
        }
    }
}