using HRManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRManager.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dashboard
        public ActionResult Index()
        {
            // Hardcoded values (for demonstration purposes)
            var model = new DashboardViewModel
            {
                TotalEmployees = 150,
                NewHires = 10,
                ActiveEmployees = 130,
                EmployeesOnLeave = 20,
                TotalDepartments = 8,
                AvgEmployeesPerDepartment = 18.75,
                RecentActivities = new List<string>
            {
                "Meeting with HR",
                "Project kick-off",
                "Training session"
            },
                LeaveRequests = 25,
                ApprovedLeaves = 15,
                PendingLeaves = 5,
                RejectedLeaves = 5,
                Announcements = new List<string>
            {
                "Company picnic next Friday!",
                "New policy updates"
            }
            };

            return View(model);
        }

    }
}