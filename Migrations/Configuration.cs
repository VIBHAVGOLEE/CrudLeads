using System.Data.Entity.Migrations;
using System.Linq;
using CrudLeads.Domain.Entities;
using CrudLeads.Infrastructure.Data;

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
        }
    }
}
