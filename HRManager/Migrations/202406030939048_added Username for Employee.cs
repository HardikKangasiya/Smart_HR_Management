namespace HRManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUsernameforEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Username", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Username");
        }
    }
}
