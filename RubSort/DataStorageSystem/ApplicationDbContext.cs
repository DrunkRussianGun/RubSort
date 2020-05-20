using Microsoft.EntityFrameworkCore;

namespace RubSort.DataStorageSystem
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        
        public DbSet<UserDbo> Users { get; set; }
        
        public DbSet<RecyclingPointDbo> RecyclingPoints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder
                .Entity<RecyclingPointDbo>()
                .OwnsOne(x => x.GeoCoordinate);

            modelBuilder
                .Entity<UserDbo>()
                .HasIndex(x => x.Email)
                .IsUnique();
        }
    }
}