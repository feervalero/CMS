using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS.Models;

namespace CMS.Views
{
    public class ClasificationsController : Controller
    {
        private ECommerce db = new ECommerce();

        // GET: Clasifications
        public async Task<ActionResult> Index()
        {
            return View(await db.Clasification.ToListAsync());
        }

        // GET: Clasifications/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clasification clasification = await db.Clasification.FindAsync(id);
            if (clasification == null)
            {
                return HttpNotFound();
            }
            return View(clasification);
        }

        // GET: Clasifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clasifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Clasification clasification)
        {
            if (ModelState.IsValid)
            {
                clasification.Id = Guid.NewGuid();
                db.Clasification.Add(clasification);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(clasification);
        }

        // GET: Clasifications/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clasification clasification = await db.Clasification.FindAsync(id);
            if (clasification == null)
            {
                return HttpNotFound();
            }
            return View(clasification);
        }

        // POST: Clasifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Clasification clasification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clasification).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(clasification);
        }

        // GET: Clasifications/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clasification clasification = await db.Clasification.FindAsync(id);
            if (clasification == null)
            {
                return HttpNotFound();
            }
            return View(clasification);
        }

        // POST: Clasifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Clasification clasification = await db.Clasification.FindAsync(id);
            db.Clasification.Remove(clasification);
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
