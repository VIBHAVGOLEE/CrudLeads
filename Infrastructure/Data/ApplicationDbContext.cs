using System.Data.Entity;
using CrudLeads.Domain.Entities;

namespace CrudLeads.Infrastructure.Data
{
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

        public virtual DbSet<Broker> Brokers { get; set; }
        public virtual DbSet<Lead> Leads { get; set; }
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<LeadSource> LeadSources { get; set; }
        public virtual DbSet<FollowUp> FollowUps { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Broker>()
                .Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Broker>()
                .Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Broker>()
                .Property(e => e.ContactNumber)
                .IsRequired()
                .HasMaxLength(12);

            modelBuilder.Entity<Broker>()
                .Property(e => e.SalesAgent)
                .HasMaxLength(200);

            modelBuilder.Entity<Broker>()
                .Property(e => e.CoOwner)
                .HasMaxLength(200);

            modelBuilder.Entity<Broker>()
                .Property(e => e.Project)
                .HasMaxLength(200);

            modelBuilder.Entity<Broker>()
                .Property(e => e.LeadSource)
                .HasMaxLength(200);

            modelBuilder.Entity<Broker>()
                .Property(e => e.ChannelPartner)
                .HasMaxLength(200);

            modelBuilder.Entity<Broker>()
                .Property(e => e.SourcingManager)
                .HasMaxLength(200);

            modelBuilder.Entity<Lead>()
                .Property(e => e.Title)
                .HasMaxLength(200);

            modelBuilder.Entity<Lead>()
                .Property(e => e.Mobile)
                .HasMaxLength(20);

            modelBuilder.Entity<Lead>()
                .Property(e => e.Stage)
                .HasMaxLength(100);

            modelBuilder.Entity<Lead>()
                .Property(e => e.Status)
                .HasMaxLength(100);

            modelBuilder.Entity<Lead>()
                .Property(e => e.Action)
                .HasMaxLength(200);

            modelBuilder.Entity<Lead>()
                .HasRequired(l => l.Broker)
                .WithMany()
                .HasForeignKey(l => l.BrokerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lead>()
                .HasRequired(l => l.ActivityType)
                .WithMany()
                .HasForeignKey(l => l.ActivityTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActivityType>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Status>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Status>()
                .Property(e => e.Category)
                .HasMaxLength(20);

            modelBuilder.Entity<LeadSource>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<FollowUp>()
                .Property(e => e.Remark)
                .HasMaxLength(500);

            modelBuilder.Entity<Customer>()
                .Property(e => e.FirstName)
                .HasMaxLength(100);

            modelBuilder.Entity<Customer>()
                .Property(e => e.LastName)
                .HasMaxLength(100);

            modelBuilder.Entity<Customer>()
                .Property(e => e.ContactNumber)
                .HasMaxLength(12);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .HasMaxLength(200);

            modelBuilder.Entity<User>()
                .Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<User>()
                .Property(e => e.PasswordSalt)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<User>()
                .HasRequired(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
