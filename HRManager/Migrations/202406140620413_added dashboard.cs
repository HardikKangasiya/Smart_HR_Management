namespace HRManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddashboard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DashboardViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalEmployees = c.Int(nullable: false),
                        TotalDepartments = c.Int(nullable: false),
                        TotalPositions = c.Int(nullable: false),
                        UpcomingHolidays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DashboardViewModels");
        }
    }
}
