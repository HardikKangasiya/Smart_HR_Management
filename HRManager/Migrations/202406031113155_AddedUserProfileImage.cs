namespace HRManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserProfileImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ProfilePicture", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ProfilePicture");
        }
    }
}
