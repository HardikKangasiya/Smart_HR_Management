namespace HRManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatetimefieldupdatedforHoliday : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HolidayModels", "HolidayDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HolidayModels", "HolidayDate", c => c.DateTime(nullable: false));
        }
    }
}
