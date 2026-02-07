using System.Data.Entity.Migrations;
using System.Linq;
using CrudLeads.Domain.Entities;
using CrudLeads.Infrastructure.Data;
using CrudLeads.Infrastructure.Security;

namespace CrudLeads.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.ActivityTypes.Any())
            {
                context.ActivityTypes.AddOrUpdate(
                    new ActivityType { Id = 1, Name = "Call" },
                    new ActivityType { Id = 2, Name = "Mail" },
                    new ActivityType { Id = 3, Name = "Meeting" },
                    new ActivityType { Id = 4, Name = "Site Visit" },
                    new ActivityType { Id = 5, Name = "Other" }
                );
                context.SaveChanges();
            }

            if (!context.Statuses.Any())
            {
                context.Statuses.AddOrUpdate(
                    s => s.Name,
                    new Status { Name = "New", Category = "Lead" },
                    new Status { Name = "Untouched", Category = "Lead" },
                    new Status { Name = "Returned", Category = "Lead" },
                    new Status { Name = "Converted", Category = "Lead" },
                    new Status { Name = "Planned", Category = "FollowUp" },
                    new Status { Name = "Done", Category = "FollowUp" },
                    new Status { Name = "NoAnswer", Category = "FollowUp" },
                    new Status { Name = "Rescheduled", Category = "FollowUp" }
                );
                context.SaveChanges();
            }

            if (!context.LeadSources.Any())
            {
                context.LeadSources.AddOrUpdate(
                    s => s.Name,
                    new LeadSource { Name = "Other" },
                    new LeadSource { Name = "Facebook" },
                    new LeadSource { Name = "99acres" }
                );
                context.SaveChanges();
            }

            if (!context.Brokers.Any())
            {
                context.Brokers.AddOrUpdate(
                    new Broker
                    {
                        FirstName = "Rahul",
                        LastName = "Sharma",
                        ContactNumber = "919876543210",
                        SalesAgent = "Agent One",
                        Project = "Project Alpha",
                        LeadSource = "Website",
                        CreatedAt = System.DateTime.UtcNow,
                        UpdatedAt = System.DateTime.UtcNow
                    },
                    new Broker
                    {
                        FirstName = "Priya",
                        LastName = "Patel",
                        ContactNumber = "919123456789",
                        SalesAgent = "Agent Two",
                        LeadSource = "Referral",
                        CreatedAt = System.DateTime.UtcNow,
                        UpdatedAt = System.DateTime.UtcNow
                    }
                );
                context.SaveChanges();
            }

            if (!context.Roles.Any())
            {
                context.Roles.AddOrUpdate(
                    r => r.Name,
                    new Role { Id = 1, Name = "Admin" },
                    new Role { Id = 2, Name = "Broker" },
                    new Role { Id = 3, Name = "EndUser" }
                );
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                string hash, salt;
                PasswordHelper.HashPassword("Admin@123", out hash, out salt);
                context.Users.AddOrUpdate(
                    u => u.UserName,
                    new User
                    {
                        Id = 1,
                        UserName = "admin",
                        Email = "admin@crudleads.local",
                        PasswordHash = hash,
                        PasswordSalt = salt,
                        RoleId = 1,
                        IsActive = true,
                        CreatedOn = System.DateTime.UtcNow
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
