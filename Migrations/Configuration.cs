using System.Data.Entity.Migrations;
using System.Linq;
using CrudLeads.Domain.Entities;
using CrudLeads.Infrastructure.Data;

namespace CrudLeads.Migrations
{
    /// <summary>
    /// EF migrations configuration with seed data.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Leads.Any())
                return;

            context.Leads.AddOrUpdate(
                new Lead
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
                new Lead
                {
                    FirstName = "Priya",
                    LastName = "Patel",
                    ContactNumber = "919123456789",
                    SalesAgent = "Agent Two",
                    LeadSource = "Referral",
                    CreatedAt = System.DateTime.UtcNow,
                    UpdatedAt = System.DateTime.UtcNow
                });
        }
    }
}
