namespace CrudLeads.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leads",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false, maxLength: 100),
                    LastName = c.String(nullable: false, maxLength: 100),
                    ContactNumber = c.String(nullable: false, maxLength: 12),
                    SalesAgent = c.String(maxLength: 200),
                    CoOwner = c.String(maxLength: 200),
                    Project = c.String(maxLength: 200),
                    LeadSource = c.String(maxLength: 200),
                    ChannelPartner = c.String(maxLength: 200),
                    SourcingManager = c.String(maxLength: 200),
                    Remark = c.String(),
                    CreatedAt = c.DateTime(nullable: false),
                    UpdatedAt = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Leads");
        }
    }
}
