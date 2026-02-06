namespace CrudLeads.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorToBrokerAndLead : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Leads");
            CreateTable(
                "dbo.ActivityTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Brokers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
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
            
            AddColumn("dbo.Leads", "BrokerId", c => c.Long(nullable: false));
            AddColumn("dbo.Leads", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Leads", "Title", c => c.String(maxLength: 200));
            AddColumn("dbo.Leads", "Mobile", c => c.String(maxLength: 20));
            AddColumn("dbo.Leads", "ActivityTypeId", c => c.Long(nullable: false));
            AddColumn("dbo.Leads", "AssignedBy", c => c.Int());
            AddColumn("dbo.Leads", "ScheduleDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Leads", "ReminderMinutes", c => c.Int());
            AddColumn("dbo.Leads", "RemindMe", c => c.Boolean(nullable: false));
            AddColumn("dbo.Leads", "Completed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Leads", "CompletedOn", c => c.DateTime());
            AddColumn("dbo.Leads", "CompletedBy", c => c.Int());
            AddColumn("dbo.Leads", "Stage", c => c.String(maxLength: 100));
            AddColumn("dbo.Leads", "Status", c => c.String(maxLength: 100));
            AddColumn("dbo.Leads", "Action", c => c.String(maxLength: 200));
            AlterColumn("dbo.Leads", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Leads", "Id");
            CreateIndex("dbo.Leads", "BrokerId");
            CreateIndex("dbo.Leads", "ActivityTypeId");
            AddForeignKey("dbo.Leads", "ActivityTypeId", "dbo.ActivityTypes", "Id");
            AddForeignKey("dbo.Leads", "BrokerId", "dbo.Brokers", "Id");
            DropColumn("dbo.Leads", "FirstName");
            DropColumn("dbo.Leads", "LastName");
            DropColumn("dbo.Leads", "ContactNumber");
            DropColumn("dbo.Leads", "SalesAgent");
            DropColumn("dbo.Leads", "CoOwner");
            DropColumn("dbo.Leads", "Project");
            DropColumn("dbo.Leads", "LeadSource");
            DropColumn("dbo.Leads", "ChannelPartner");
            DropColumn("dbo.Leads", "SourcingManager");
            DropColumn("dbo.Leads", "CreatedAt");
            DropColumn("dbo.Leads", "UpdatedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leads", "UpdatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Leads", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Leads", "SourcingManager", c => c.String(maxLength: 200));
            AddColumn("dbo.Leads", "ChannelPartner", c => c.String(maxLength: 200));
            AddColumn("dbo.Leads", "LeadSource", c => c.String(maxLength: 200));
            AddColumn("dbo.Leads", "Project", c => c.String(maxLength: 200));
            AddColumn("dbo.Leads", "CoOwner", c => c.String(maxLength: 200));
            AddColumn("dbo.Leads", "SalesAgent", c => c.String(maxLength: 200));
            AddColumn("dbo.Leads", "ContactNumber", c => c.String(nullable: false, maxLength: 12));
            AddColumn("dbo.Leads", "LastName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Leads", "FirstName", c => c.String(nullable: false, maxLength: 100));
            DropForeignKey("dbo.Leads", "BrokerId", "dbo.Brokers");
            DropForeignKey("dbo.Leads", "ActivityTypeId", "dbo.ActivityTypes");
            DropIndex("dbo.Leads", new[] { "ActivityTypeId" });
            DropIndex("dbo.Leads", new[] { "BrokerId" });
            DropPrimaryKey("dbo.Leads");
            AlterColumn("dbo.Leads", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Leads", "Action");
            DropColumn("dbo.Leads", "Status");
            DropColumn("dbo.Leads", "Stage");
            DropColumn("dbo.Leads", "CompletedBy");
            DropColumn("dbo.Leads", "CompletedOn");
            DropColumn("dbo.Leads", "Completed");
            DropColumn("dbo.Leads", "RemindMe");
            DropColumn("dbo.Leads", "ReminderMinutes");
            DropColumn("dbo.Leads", "ScheduleDate");
            DropColumn("dbo.Leads", "AssignedBy");
            DropColumn("dbo.Leads", "ActivityTypeId");
            DropColumn("dbo.Leads", "Mobile");
            DropColumn("dbo.Leads", "Title");
            DropColumn("dbo.Leads", "CreatedDate");
            DropColumn("dbo.Leads", "BrokerId");
            DropTable("dbo.Brokers");
            DropTable("dbo.ActivityTypes");
            AddPrimaryKey("dbo.Leads", "Id");
        }
    }
}
