using Microsoft.EntityFrameworkCore;
using Thelegend107.MySQL.Data.Lib.Entities;

namespace Thelegend107.MySQL.Data.Lib
{
    public class DatawarehouseContext : DbContext
    {
        public readonly string connectionString;

        public DatawarehouseContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(this.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Navigation(d => d.Country);
                entity.Navigation(d => d.State);
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Navigation(d => d.Address);
                entity.Navigation(d => d.EducationItems);
            });

            modelBuilder.Entity<WorkExperience>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Navigation(d => d.Address);
                entity.Navigation(d => d.WorkExperienceItems);
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<EducationItem> EducationItems { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<WorkExperienceItem> WorkExperienceItems { get; set;}
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Link> Links { get; set; }
        
        public DbSet<Region> Regions { get; set; }
        public DbSet<SubRegion> SubRegions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
    }
}
