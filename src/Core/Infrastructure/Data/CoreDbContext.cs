using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using Ultra.Core.Domain.Entities;

namespace Ultra.Core.Infrastructure.Data
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext() : base(IoC.Resolve<CoreDbContextConnectionString>().ConnectionString)
        {
            Database.SetInitializer<CoreDbContext>(
                new MigrateDatabaseToLatestVersion<CoreDbContext, CoreDbConfiguration>());
        }

        public virtual DbSet<Parking> Parkings { get; set; }
        public virtual DbSet<ParkingPlace> ParkingsPlaces { get; set; }
        public virtual DbSet<ParkingSegment> ParkingSegments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ParkingPlace>()
                .HasKey(place => new { place.ParkingId, place.SegmentId, place.Id});

            modelBuilder.Entity<ParkingSegment>()
                .HasKey(segment => new {segment.ParkingId, segment.Id});

            modelBuilder.Entity<Parking>()
                .HasMany(p => p.Segments)
                .WithRequired(s => s.Parking)
                .HasForeignKey(s => s.ParkingId);
            modelBuilder.Entity<ParkingPlace>()
                .HasRequired(p => p.Parking)
                .WithMany()
                .HasForeignKey(p => p.ParkingId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ParkingSegment>()
                .HasMany(s => s.Places)
                .WithRequired(p => p.Segment)
                .HasForeignKey(p => new { p.ParkingId, p.SegmentId});
        }
    }

    public class CoreDbContextConnectionString
    {
        public CoreDbContextConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }
    }

    public class CoreDbConfiguration : DbMigrationsConfiguration<CoreDbContext>
    {
        public CoreDbConfiguration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }
    }
}