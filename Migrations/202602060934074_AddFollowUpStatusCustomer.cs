namespace CrudLeads.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowUpStatusCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BrokerId = c.Long(nullable: false),
                        LeadId = c.Long(nullable: false),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        ContactNumber = c.String(maxLength: 12),
                        LeadSourceId = c.Long(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FollowUps",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BrokerId = c.Long(nullable: false),
                        LeadId = c.Long(),
                        FollowUpDate = c.DateTime(nullable: false),
                        Remark = c.String(maxLength: 500),
                        StatusId = c.Long(),
                        IsCompleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brokers", t => t.BrokerId, cascadeDelete: true)
                .ForeignKey("dbo.Leads", t => t.LeadId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.BrokerId)
                .Index(t => t.LeadId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Category = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LeadSources",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FollowUps", "StatusId", "dbo.Status");
            DropForeignKey("dbo.FollowUps", "LeadId", "dbo.Leads");
            DropForeignKey("dbo.FollowUps", "BrokerId", "dbo.Brokers");
            DropIndex("dbo.FollowUps", new[] { "StatusId" });
            DropIndex("dbo.FollowUps", new[] { "LeadId" });
            DropIndex("dbo.FollowUps", new[] { "BrokerId" });
            DropTable("dbo.LeadSources");
            DropTable("dbo.Status");
            DropTable("dbo.FollowUps");
            DropTable("dbo.Customers");
        }
    }
}
