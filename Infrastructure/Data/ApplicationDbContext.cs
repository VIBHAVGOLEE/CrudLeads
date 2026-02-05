using System.Data.Entity;
using CrudLeads.Domain.Entities;

namespace CrudLeads.Infrastructure.Data
{
    /// <summary>
    /// EF Code First DbContext for the application.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=DefaultConnection")
        {
        }

        public ApplicationDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual DbSet<Lead> Leads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lead>()
                .Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Lead>()
                .Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Lead>()
                .Property(e => e.ContactNumber)
                .IsRequired()
                .HasMaxLength(12);

            modelBuilder.Entity<Lead>()
                .Property(e => e.SalesAgent)
                .HasMaxLength(200);

            modelBuilder.Entity<Lead>()
                .Property(e => e.CoOwner)
                .HasMaxLength(200);

            modelBuilder.Entity<Lead>()
                .Property(e => e.Project)
                .HasMaxLength(200);

            modelBuilder.Entity<Lead>()
                .Property(e => e.LeadSource)
                .HasMaxLength(200);

            modelBuilder.Entity<Lead>()
                .Property(e => e.ChannelPartner)
                .HasMaxLength(200);

            modelBuilder.Entity<Lead>()
                .Property(e => e.SourcingManager)
                .HasMaxLength(200);

            base.OnModelCreating(modelBuilder);
        }
    }
}
