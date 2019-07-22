using Microsoft.EntityFrameworkCore;

namespace ServiceBook.API.Entities
{
    public class ServiceBookContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<Tfm> Tfms { get; set; }

        public DbSet<ObjectType> ObjectTypes { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Object> Objects { get; set; }

        public DbSet<ObjectUser> ObjectUsers { get; set; }

        public DbSet<ObjectDepartment> ObjectDepartments { get; set; }

        public ServiceBookContext(DbContextOptions<ServiceBookContext> options)
           : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObjectUser>().HasKey(sc => new { sc.ObjectId, sc.UserId });
            modelBuilder.Entity<ObjectUser>().HasOne(bc => bc.Object).WithMany(b => b.ObjectUsers).HasForeignKey(bc => bc.ObjectId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ObjectDepartment>().HasKey(sc => new { sc.ObjectId, sc.DepartmentId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
