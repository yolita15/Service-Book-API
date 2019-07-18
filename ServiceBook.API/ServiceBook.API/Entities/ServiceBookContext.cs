using Microsoft.EntityFrameworkCore;

namespace SB.API.Entities
{
    public class ServiceBookContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<Tfm> Tfms { get; set; }

        public DbSet<ObjectType> Types { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Object> Objects { get; set; }

        public DbSet<CompanyProviders> CompanyProviders { get; set; }

       // public DbSet<ObjectUsers> ObjectUsers { get; set; }

        public DbSet<ObjectDepartment> ObjectDepartments { get; set; }

        public ServiceBookContext(DbContextOptions<ServiceBookContext> options)
           : base(options)
        {
            Database.Migrate();
        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyProviders>().HasKey(sc => new { sc.CompanyId, sc.ProviderId });
           // modelBuilder.Entity<ObjectUsers>().HasKey(sc => new { sc.ObjectId, sc.UserId });
            modelBuilder.Entity<ObjectDepartment>().HasKey(sc => new { sc.ObjectId, sc.DepartmentId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
