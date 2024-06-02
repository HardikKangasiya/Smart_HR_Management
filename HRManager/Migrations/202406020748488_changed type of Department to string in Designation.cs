namespace HRManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtypeofDepartmenttostringinDesignation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DesignationModels", "Department_DepartmentID", "dbo.DepartmentModels");
            DropIndex("dbo.DesignationModels", new[] { "Department_DepartmentID" });
            AddColumn("dbo.DesignationModels", "Department", c => c.String(nullable: false));
            DropColumn("dbo.DesignationModels", "Department_DepartmentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DesignationModels", "Department_DepartmentID", c => c.Int(nullable: false));
            DropColumn("dbo.DesignationModels", "Department");
            CreateIndex("dbo.DesignationModels", "Department_DepartmentID");
            AddForeignKey("dbo.DesignationModels", "Department_DepartmentID", "dbo.DepartmentModels", "DepartmentID", cascadeDelete: true);
        }
    }
}
