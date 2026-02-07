namespace CrudLeads.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLeadNameFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leads", "FirstName", c => c.String(maxLength: 100));
            AddColumn("dbo.Leads", "LastName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leads", "LastName");
            DropColumn("dbo.Leads", "FirstName");
        }
    }
}
