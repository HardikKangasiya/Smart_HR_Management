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

namespace HRManager.Controllers
{
    public class DesignationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Designation
        public async Task<ActionResult> Index()
        {
            return View(await db.DesignationModels.ToListAsync());
        }

        // GET: Designation/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignationModel designationModel = await db.DesignationModels.FindAsync(id);
            if (designationModel == null)
            {
                return HttpNotFound();
            }
            return View(designationModel);
        }

        // GET: Designation/Create
        public ActionResult Create()
        {
            ViewBag.Department = new SelectList(db.DepartmentModels, "DepartmentName", "DepartmentName");
            return View();
        }

        // POST: Designation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DesignationID,DesignationName,Department")] DesignationModel designationModel)
        {
            if (ModelState.IsValid)
            {
                db.DesignationModels.Add(designationModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(designationModel);
        }

        // GET: Designation/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            // Get the department list
            List<DepartmentModel> departments = db.DepartmentModels.ToList();

            // Create a SelectList for the DropDownListFor
            ViewBag.CustomDepartment = new SelectList(departments, "DepartmentName", "DepartmentName");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignationModel designationModel = await db.DesignationModels.FindAsync(id);
            if (designationModel == null)
            {
                return HttpNotFound();
            }
            return View(designationModel);
        }

        // POST: Designation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DesignationID,DesignationName,Department")] DesignationModel designationModel)
        {
            // Get the department list
            List<DepartmentModel> departments = db.DepartmentModels.ToList();

            // Create a SelectList for the DropDownListFor
            ViewBag.CustomDepartment = new SelectList(departments, "DepartmentName", "DepartmentName");

            if (ModelState.IsValid)
            {
                db.Entry(designationModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(designationModel);
        }

        // GET: Designation/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignationModel designationModel = await db.DesignationModels.FindAsync(id);
            if (designationModel == null)
            {
                return HttpNotFound();
            }
            return View(designationModel);
        }

        // POST: Designation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DesignationModel designationModel = await db.DesignationModels.FindAsync(id);
            db.DesignationModels.Remove(designationModel);
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
