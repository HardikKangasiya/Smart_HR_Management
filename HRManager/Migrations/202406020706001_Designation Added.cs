namespace HRManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DesignationAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DesignationModels",
                c => new
                    {
                        DesignationID = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(nullable: false),
                        Department_DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DesignationID)
                .ForeignKey("dbo.DepartmentModels", t => t.Department_DepartmentID, cascadeDelete: true)
                .Index(t => t.Department_DepartmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DesignationModels", "Department_DepartmentID", "dbo.DepartmentModels");
            DropIndex("dbo.DesignationModels", new[] { "Department_DepartmentID" });
            DropTable("dbo.DesignationModels");
        }
    }
}
