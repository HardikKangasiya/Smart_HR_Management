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
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employee
        public async Task<ActionResult> Index()
        {
            return View(await db.Employee.ToListAsync());
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
            // Get the department list
            List<DepartmentModel> departments = db.DepartmentModels.ToList();

            // Create a SelectList for the DropDownListFor
            ViewBag.Department = departments;

            // Get the designation list
            List<DesignationModel> designations = db.DesignationModels.ToList();

            // Create a SelectList for the DropDownListFor
            ViewBag.Designation = designations;

            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmployeeID,Username,FirstName,LastName,Email,JoiningDate,Phone,Department,Designation")] Employee employee, HttpPostedFileBase ProfilePicture)
        {   // Get the department list
            List<DepartmentModel> departments = db.DepartmentModels.ToList();

            // Create a SelectList for the DropDownListFor
            ViewBag.Department = departments;

            // Get the designation list
            List<DesignationModel> designations = db.DesignationModels.ToList();

            // Create a SelectList for the DropDownListFor
            ViewBag.Designation = designations;

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
            // Get the department list
            List<DepartmentModel> departments = db.DepartmentModels.ToList();

            // Create a SelectList for the DropDownListFor
            ViewBag.CustomDepartment = new SelectList(departments, "DepartmentName", "DepartmentName");

            // Get the designation list
            List<DesignationModel> designations = db.DesignationModels.ToList();

            // Create a SelectList for the DropDownListFor
            ViewBag.CustomDesignation = new SelectList(designations, "DesignationName", "DesignationName");

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

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EmployeeID,Username,FirstName,LastName,Email,JoiningDate,Phone,Department,Designation")] Employee employee)
        {
            // Get the department list
            List<DepartmentModel> departments = db.DepartmentModels.ToList();

            // Create a SelectList for the DropDownListFor
            ViewBag.CustomDepartment = new SelectList(departments, "DepartmentName", "DepartmentName");

            // Get the designation list
            List<DesignationModel> designations = db.DesignationModels.ToList();

            // Create a SelectList for the DropDownListFor
            ViewBag.CustomDesignation = new SelectList(designations, "DesignationName", "DesignationName");

            if (ModelState.IsValid)
            {
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
            return View(employee);
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
