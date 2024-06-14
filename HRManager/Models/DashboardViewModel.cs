using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRManager.Models
{
    public class DashboardViewModel
    {
        [Key]
        public int Id { get; set; }
        public int TotalEmployees { get; set; }
        public int NewHires { get; set; }
        public int ActiveEmployees { get; set; }
        public int EmployeesOnLeave { get; set; }
        public int TotalDepartments { get; set; }
        public double AvgEmployeesPerDepartment { get; set; }
        public IEnumerable<string> RecentActivities { get; set; }
        public int LeaveRequests { get; set; }
        public int ApprovedLeaves { get; set; }
        public int PendingLeaves { get; set; }
        public int RejectedLeaves { get; set; }
        public IEnumerable<string> Announcements { get; set; }
    }

}