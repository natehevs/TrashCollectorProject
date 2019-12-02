namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suspendStartEndDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "startSuspended", c => c.String());
            AddColumn("dbo.Customers", "endSuspended", c => c.String());
            DropColumn("dbo.Customers", "isSuspended");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "isSuspended", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "endSuspended");
            DropColumn("dbo.Customers", "startSuspended");
        }
    }
}
