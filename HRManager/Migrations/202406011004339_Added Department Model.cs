namespace HRManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDepartmentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentModels",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DepartmentModels");
        }
    }
}
