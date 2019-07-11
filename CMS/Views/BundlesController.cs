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
    public class BundlesController : Controller
    {
        private ECommerce db = new ECommerce();

        // GET: Bundles
        public async Task<ActionResult> Index()
        {
            var bundle = db.Bundle.Include(b => b.Clasification).Include(b => b.Image);
            return View(await bundle.ToListAsync());
        }

        // GET: Bundles/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bundle bundle = await db.Bundle.FindAsync(id);
            if (bundle == null)
            {
                return HttpNotFound();
            }
            return View(bundle);
        }

        // GET: Bundles/Create
        public ActionResult Create()
        {
            ViewBag.ClasificationId = new SelectList(db.Clasification, "Id", "Name");
            ViewBag.ImageId = new SelectList(db.Image, "Id", "Name");
            return View();
        }

        // POST: Bundles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ClasificationId,ImageId,Name,Description")] Bundle bundle)
        {
            if (ModelState.IsValid)
            {
                bundle.Id = Guid.NewGuid();
                db.Bundle.Add(bundle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClasificationId = new SelectList(db.Clasification, "Id", "Name", bundle.ClasificationId);
            ViewBag.ImageId = new SelectList(db.Image, "Id", "Name", bundle.ImageId);
            return View(bundle);
        }

        // GET: Bundles/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bundle bundle = await db.Bundle.FindAsync(id);
            if (bundle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClasificationId = new SelectList(db.Clasification, "Id", "Name", bundle.ClasificationId);
            ViewBag.ImageId = new SelectList(db.Image, "Id", "Name", bundle.ImageId);
            return View(bundle);
        }

        // POST: Bundles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ClasificationId,ImageId,Name,Description")] Bundle bundle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bundle).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClasificationId = new SelectList(db.Clasification, "Id", "Name", bundle.ClasificationId);
            ViewBag.ImageId = new SelectList(db.Image, "Id", "Name", bundle.ImageId);
            return View(bundle);
        }

        // GET: Bundles/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bundle bundle = await db.Bundle.FindAsync(id);
            if (bundle == null)
            {
                return HttpNotFound();
            }
            return View(bundle);
        }

        // POST: Bundles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Bundle bundle = await db.Bundle.FindAsync(id);
            db.Bundle.Remove(bundle);
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
