using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HRManager.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Add additional profile data for application users by adding properties to this class
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeID { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("CustomConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Explicitly map JoiningDate to datetime2
            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.JoiningDate)
                .HasColumnType("datetime2");

            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<HRManager.Models.DepartmentModel> DepartmentModels { get; set; }
    }
}
