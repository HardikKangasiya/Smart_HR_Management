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
    [Authorize]
    public class DepartmentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Department
        public async Task<ActionResult> Index()
        {
            return View(await db.DepartmentModels.ToListAsync());
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DepartmentID,DepartmentName")] DepartmentModel departmentModel)
        {
            if (ModelState.IsValid)
            {
                db.DepartmentModels.Add(departmentModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(departmentModel);
        }

        // GET: Department/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentModel departmentModel = await db.DepartmentModels.FindAsync(id);
            if (departmentModel == null)
            {
                return HttpNotFound();
            }
            return View(departmentModel);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DepartmentID,DepartmentName")] DepartmentModel departmentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departmentModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(departmentModel);
        }

        // GET: Department/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentModel departmentModel = await db.DepartmentModels.FindAsync(id);
            if (departmentModel == null)
            {
                return HttpNotFound();
            }
            return View(departmentModel);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DepartmentModel departmentModel = await db.DepartmentModels.FindAsync(id);
            db.DepartmentModels.Remove(departmentModel);
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
