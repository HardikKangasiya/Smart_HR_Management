using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRManager.Models;
using System.IO;

namespace HRManager.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employee
        public async Task<ActionResult> Index()
        {
            ViewData["PageName"] = "Employee";
            return View("~/Views/Shared/CRUD/_IndexPartial.cshtml", await db.Employee.ToListAsync());
        }

        [HttpGet]
        public ActionResult GetProfilePicture(int employeeId)
        {
            var employee = db.Employee.Find(employeeId);
            if (employee?.ProfilePicture != null)
            {
                return File(employee.ProfilePicture, "image/*"); // Adjust content type as needed
            }
            else
            {
                // Return a default image or placeholder
                return File(Server.MapPath("~/Content/default-profile.jpg"), "image/jpeg");
            }
        }


        // GET: Employee/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employee.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            // Create a SelectList for the DropDownListFor
            ViewBag.Department = new SelectList(db.DepartmentModels, "DepartmentName", "DepartmentName");

            // Create a SelectList for the DropDownListFor
            ViewBag.Designation = new SelectList(db.DesignationModels, "DesignationName", "DesignationName");

            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmployeeID,Username,FirstName,LastName,Email,JoiningDate,Phone,Department,Designation")] Employee employee, HttpPostedFileBase ProfilePicture)
        {   

            // Create a SelectList for the DropDownListFor
            ViewBag.Department = new SelectList(db.DepartmentModels, "DepartmentName", "DepartmentName");

            // Create a SelectList for the DropDownListFor
            ViewBag.Designation = new SelectList(db.DesignationModels, "DesignationName", "DesignationName");

            // Check if an image was uploaded
            if (ProfilePicture != null && ProfilePicture.ContentLength > 0)
            {
                // Read the uploaded image file into a byte array
                using (var binaryReader = new BinaryReader(ProfilePicture.InputStream))
                {
                    employee.ProfilePicture = binaryReader.ReadBytes(ProfilePicture.ContentLength);
                }

                if (ModelState.IsValid)
                {

                    // Add the employee to the database context
                    db.Employee.Add(employee);
                    await db.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "Profile Image is required");
            }

            return View(employee);
        }



        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            // Create a SelectList for the DropDownListFor
            ViewBag.CustomDepartment = new SelectList(db.DepartmentModels, "DepartmentName", "DepartmentName");

            // Create a SelectList for the DropDownListFor
            ViewBag.CustomDesignation = new SelectList(db.DesignationModels, "DesignationName", "DesignationName");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employee.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.JoiningDate_string = employee.JoiningDate.ToString("yyyy-MM-ddTHH:mm");
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EmployeeID,Username,FirstName,LastName,Email,JoiningDate,Phone,Department,Designation,ProfilePicture")] Employee employee, HttpPostedFileBase ProfilePictureFile)
        {
            // Create a SelectList for the DropDownListFor
            ViewBag.CustomDepartment = new SelectList(db.DepartmentModels, "DepartmentName", "DepartmentName");

            // Create a SelectList for the DropDownListFor
            ViewBag.CustomDesignation = new SelectList(db.DesignationModels, "DesignationName", "DesignationName");

            if (ModelState.IsValid)
            {
                if (ProfilePictureFile != null && ProfilePictureFile.ContentLength > 0)
                {
                    // Read the uploaded image file into a byte array
                    using (var binaryReader = new BinaryReader(ProfilePictureFile.InputStream))
                    {
                        employee.ProfilePicture = binaryReader.ReadBytes(ProfilePictureFile.ContentLength);
                    }
                }

                db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(employee);
        }


        // GET: Employee/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employee.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewData["excludeProperties"] = new List<string> { "DesignationID", "ProfilePicture" };
            return View("~/Views/Shared/CRUD/_DeletePartial.cshtml", employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee employee = await db.Employee.FindAsync(id);
            db.Employee.Remove(employee);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
