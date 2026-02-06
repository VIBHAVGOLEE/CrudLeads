namespace CrudLeads.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public class RenameLeadToBrokerAndCreateNewTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Leads", newName: "Brokers");
            AlterColumn("dbo.Brokers", "Id", c => c.Long(nullable: false, identity: true));
            CreateTable(
                "dbo.ActivityTypes",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.Id);
            CreateTable(
                "dbo.Leads",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    BrokerId = c.Long(nullable: false),
                    CreatedDate = c.DateTime(nullable: false),
                    Title = c.String(maxLength: 200),
                    Remark = c.String(),
                    Mobile = c.String(maxLength: 20),
                    ActivityTypeId = c.Long(nullable: false),
                    AssignedBy = c.Int(),
                    ScheduleDate = c.DateTime(nullable: false),
                    ReminderMinutes = c.Int(),
                    RemindMe = c.Boolean(nullable: false),
                    Completed = c.Boolean(nullable: false),
                    CompletedOn = c.DateTime(),
                    CompletedBy = c.Int(),
                    Stage = c.String(maxLength: 100),
                    Status = c.String(maxLength: 100),
                    Action = c.String(maxLength: 200),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brokers", t => t.BrokerId)
                .ForeignKey("dbo.ActivityTypes", t => t.ActivityTypeId)
                .Index(t => t.BrokerId)
                .Index(t => t.ActivityTypeId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Leads", "ActivityTypeId", "dbo.ActivityTypes");
            DropForeignKey("dbo.Leads", "BrokerId", "dbo.Brokers");
            DropIndex("dbo.Leads", new[] { "ActivityTypeId" });
            DropIndex("dbo.Leads", new[] { "BrokerId" });
            DropTable("dbo.Leads");
            DropTable("dbo.ActivityTypes");
            AlterColumn("dbo.Brokers", "Id", c => c.Int(nullable: false, identity: true));
            RenameTable(name: "dbo.Brokers", newName: "Leads");
        }
    }
}
