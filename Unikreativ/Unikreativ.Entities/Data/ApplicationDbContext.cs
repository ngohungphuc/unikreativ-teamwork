using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Entities.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Billing> Billings { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TasksRequest> TasksRequests { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }

        public ApplicationDbContext()
            : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=Unikreativ;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        //public override int SaveChanges()
        //{
        //    this.ChangeTracker.DetectChanges();

        //    var entries = this.ChangeTracker.Entries<CartItem>()
        //        .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        //    foreach (var entry in entries)
        //    {
        //        entry.Property("LastUpdated").CurrentValue = DateTime.UtcNow;
        //    }

        //    return base.SaveChanges();
        //}
    }
}