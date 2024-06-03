namespace HRManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "ProfilePicture", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "ProfilePicture", c => c.Binary(nullable: false));
        }
    }
}
