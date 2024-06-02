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
    public class HolidayController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Holiday
        public async Task<ActionResult> Index()
        {
            return View(await db.HolidayModels.ToListAsync());
        }

        // GET: Holiday/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Holiday/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "HolidayID,HolidayName,HolidayDate")] HolidayModel holidayModel)
        {
            if (ModelState.IsValid)
            {
                db.HolidayModels.Add(holidayModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(holidayModel);
        }

        // GET: Holiday/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HolidayModel holidayModel = await db.HolidayModels.FindAsync(id);
            if (holidayModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.HolidayDate_string = holidayModel.HolidayDate.ToString("yyyy-MM-ddTHH:mm");

            return View(holidayModel);
        }

        // POST: Holiday/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "HolidayID,HolidayName,HolidayDate")] HolidayModel holidayModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(holidayModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(holidayModel);
        }

        // GET: Holiday/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HolidayModel holidayModel = await db.HolidayModels.FindAsync(id);
            if (holidayModel == null)
            {
                return HttpNotFound();
            }
            return View(holidayModel);
        }

        // POST: Holiday/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HolidayModel holidayModel = await db.HolidayModels.FindAsync(id);
            db.HolidayModels.Remove(holidayModel);
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
