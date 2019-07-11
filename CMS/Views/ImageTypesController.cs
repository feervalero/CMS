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
    public class ImageTypesController : Controller
    {
        private ECommerce db = new ECommerce();

        // GET: ImageTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.ImageType.ToListAsync());
        }

        // GET: ImageTypes/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageType imageType = await db.ImageType.FindAsync(id);
            if (imageType == null)
            {
                return HttpNotFound();
            }
            return View(imageType);
        }

        // GET: ImageTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImageTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] ImageType imageType)
        {
            if (ModelState.IsValid)
            {
                imageType.Id = Guid.NewGuid();
                db.ImageType.Add(imageType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(imageType);
        }

        // GET: ImageTypes/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageType imageType = await db.ImageType.FindAsync(id);
            if (imageType == null)
            {
                return HttpNotFound();
            }
            return View(imageType);
        }

        // POST: ImageTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] ImageType imageType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(imageType);
        }

        // GET: ImageTypes/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageType imageType = await db.ImageType.FindAsync(id);
            if (imageType == null)
            {
                return HttpNotFound();
            }
            return View(imageType);
        }

        // POST: ImageTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ImageType imageType = await db.ImageType.FindAsync(id);
            db.ImageType.Remove(imageType);
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
