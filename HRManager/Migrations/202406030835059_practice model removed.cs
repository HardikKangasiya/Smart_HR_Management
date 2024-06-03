namespace HRManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class practicemodelremoved : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.PracticeModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PracticeModels",
                c => new
                    {
                        PracticeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PracticeID);
            
        }
    }
}
