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
    public class FeaturesController : Controller
    {
        private ECommerce db = new ECommerce();

        // GET: Features
        public async Task<ActionResult> Index()
        {
            var feature = db.Feature.Include(f => f.FeatureType);
            return View(await feature.ToListAsync());
        }

        // GET: Features/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature feature = await db.Feature.FindAsync(id);
            if (feature == null)
            {
                return HttpNotFound();
            }
            return View(feature);
        }

        // GET: Features/Create
        public ActionResult Create()
        {
            ViewBag.FeatureTypeId = new SelectList(db.FeatureType, "Id", "Value");
            return View();
        }

        // POST: Features/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FeatureTypeId,Title,Description,URL")] Feature feature)
        {
            if (ModelState.IsValid)
            {
                feature.Id = Guid.NewGuid();
                db.Feature.Add(feature);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FeatureTypeId = new SelectList(db.FeatureType, "Id", "Value", feature.FeatureTypeId);
            return View(feature);
        }

        // GET: Features/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature feature = await db.Feature.FindAsync(id);
            if (feature == null)
            {
                return HttpNotFound();
            }
            ViewBag.FeatureTypeId = new SelectList(db.FeatureType, "Id", "Value", feature.FeatureTypeId);
            return View(feature);
        }

        // POST: Features/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FeatureTypeId,Title,Description,URL")] Feature feature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feature).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FeatureTypeId = new SelectList(db.FeatureType, "Id", "Value", feature.FeatureTypeId);
            return View(feature);
        }

        // GET: Features/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature feature = await db.Feature.FindAsync(id);
            if (feature == null)
            {
                return HttpNotFound();
            }
            return View(feature);
        }

        // POST: Features/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Feature feature = await db.Feature.FindAsync(id);
            db.Feature.Remove(feature);
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
