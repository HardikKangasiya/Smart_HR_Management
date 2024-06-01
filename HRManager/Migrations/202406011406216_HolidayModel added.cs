namespace HRManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HolidayModeladded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HolidayModels",
                c => new
                    {
                        HolidayID = c.Int(nullable: false, identity: true),
                        HolidayName = c.String(nullable: false),
                        HolidayDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HolidayID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HolidayModels");
        }
    }
}
