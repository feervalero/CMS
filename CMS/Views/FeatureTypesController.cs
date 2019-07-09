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
    public class FeatureTypesController : Controller
    {
        private ECommerce db = new ECommerce();

        // GET: FeatureTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.FeatureType.ToListAsync());
        }

        // GET: FeatureTypes/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeatureType featureType = await db.FeatureType.FindAsync(id);
            if (featureType == null)
            {
                return HttpNotFound();
            }
            return View(featureType);
        }

        // GET: FeatureTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeatureTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Value,Name")] FeatureType featureType)
        {
            if (ModelState.IsValid)
            {
                featureType.Id = Guid.NewGuid();
                db.FeatureType.Add(featureType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(featureType);
        }

        // GET: FeatureTypes/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeatureType featureType = await db.FeatureType.FindAsync(id);
            if (featureType == null)
            {
                return HttpNotFound();
            }
            return View(featureType);
        }

        // POST: FeatureTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Value,Name")] FeatureType featureType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(featureType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(featureType);
        }

        // GET: FeatureTypes/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeatureType featureType = await db.FeatureType.FindAsync(id);
            if (featureType == null)
            {
                return HttpNotFound();
            }
            return View(featureType);
        }

        // POST: FeatureTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            FeatureType featureType = await db.FeatureType.FindAsync(id);
            db.FeatureType.Remove(featureType);
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
