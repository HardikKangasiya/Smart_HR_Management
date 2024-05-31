namespace HRManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationWithCustomProfileFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "EmployeeID", c => c.String());
            AddColumn("dbo.AspNetUsers", "JoiningDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String());
            AddColumn("dbo.AspNetUsers", "Company", c => c.String());
            AddColumn("dbo.AspNetUsers", "Department", c => c.String());
            AddColumn("dbo.AspNetUsers", "Designation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Designation");
            DropColumn("dbo.AspNetUsers", "Department");
            DropColumn("dbo.AspNetUsers", "Company");
            DropColumn("dbo.AspNetUsers", "Phone");
            DropColumn("dbo.AspNetUsers", "JoiningDate");
            DropColumn("dbo.AspNetUsers", "EmployeeID");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
