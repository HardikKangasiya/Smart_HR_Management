namespace HRManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddashboard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DashboardViewModels", "NewHires", c => c.Int(nullable: false));
            AddColumn("dbo.DashboardViewModels", "ActiveEmployees", c => c.Int(nullable: false));
            AddColumn("dbo.DashboardViewModels", "EmployeesOnLeave", c => c.Int(nullable: false));
            AddColumn("dbo.DashboardViewModels", "AvgEmployeesPerDepartment", c => c.Double(nullable: false));
            AddColumn("dbo.DashboardViewModels", "LeaveRequests", c => c.Int(nullable: false));
            AddColumn("dbo.DashboardViewModels", "ApprovedLeaves", c => c.Int(nullable: false));
            AddColumn("dbo.DashboardViewModels", "PendingLeaves", c => c.Int(nullable: false));
            AddColumn("dbo.DashboardViewModels", "RejectedLeaves", c => c.Int(nullable: false));
            DropColumn("dbo.DashboardViewModels", "TotalPositions");
            DropColumn("dbo.DashboardViewModels", "UpcomingHolidays");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DashboardViewModels", "UpcomingHolidays", c => c.Int(nullable: false));
            AddColumn("dbo.DashboardViewModels", "TotalPositions", c => c.Int(nullable: false));
            DropColumn("dbo.DashboardViewModels", "RejectedLeaves");
            DropColumn("dbo.DashboardViewModels", "PendingLeaves");
            DropColumn("dbo.DashboardViewModels", "ApprovedLeaves");
            DropColumn("dbo.DashboardViewModels", "LeaveRequests");
            DropColumn("dbo.DashboardViewModels", "AvgEmployeesPerDepartment");
            DropColumn("dbo.DashboardViewModels", "EmployeesOnLeave");
            DropColumn("dbo.DashboardViewModels", "ActiveEmployees");
            DropColumn("dbo.DashboardViewModels", "NewHires");
        }
    }
}
