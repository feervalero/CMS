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
    public class ProductToBundlesController : Controller
    {
        private ECommerce db = new ECommerce();

        // GET: ProductToBundles
        public async Task<ActionResult> Index()
        {
            var productToBundle = db.ProductToBundle.Include(p => p.Bundle).Include(p => p.PriceList).Include(p => p.Product);
            return View(await productToBundle.ToListAsync());
        }

        // GET: ProductToBundles/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductToBundle productToBundle = await db.ProductToBundle.FindAsync(id);
            if (productToBundle == null)
            {
                return HttpNotFound();
            }
            return View(productToBundle);
        }

        // GET: ProductToBundles/Create
        public ActionResult Create()
        {
            ViewBag.BundleId = new SelectList(db.Bundle, "Id", "Name");
            ViewBag.PriceListId = new SelectList(db.PriceList, "Id", "PriceListValue");
            ViewBag.ProductId = new SelectList(db.Product, "Id", "Title");
            return View();
        }

        // POST: ProductToBundles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,BundleId,ProductId,PriceListId,Name,Level")] ProductToBundle productToBundle)
        {
            if (ModelState.IsValid)
            {
                productToBundle.Id = Guid.NewGuid();
                db.ProductToBundle.Add(productToBundle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BundleId = new SelectList(db.Bundle, "Id", "Name", productToBundle.BundleId);
            ViewBag.PriceListId = new SelectList(db.PriceList, "Id", "PriceListValue", productToBundle.PriceListId);
            ViewBag.ProductId = new SelectList(db.Product, "Id", "Title", productToBundle.ProductId);
            return View(productToBundle);
        }

        // GET: ProductToBundles/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductToBundle productToBundle = await db.ProductToBundle.FindAsync(id);
            if (productToBundle == null)
            {
                return HttpNotFound();
            }
            ViewBag.BundleId = new SelectList(db.Bundle, "Id", "Name", productToBundle.BundleId);
            ViewBag.PriceListId = new SelectList(db.PriceList, "Id", "PriceListValue", productToBundle.PriceListId);
            ViewBag.ProductId = new SelectList(db.Product, "Id", "Title", productToBundle.ProductId);
            return View(productToBundle);
        }

        // POST: ProductToBundles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,BundleId,ProductId,PriceListId,Name,Level")] ProductToBundle productToBundle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productToBundle).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BundleId = new SelectList(db.Bundle, "Id", "Name", productToBundle.BundleId);
            ViewBag.PriceListId = new SelectList(db.PriceList, "Id", "PriceListValue", productToBundle.PriceListId);
            ViewBag.ProductId = new SelectList(db.Product, "Id", "Title", productToBundle.ProductId);
            return View(productToBundle);
        }

        // GET: ProductToBundles/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductToBundle productToBundle = await db.ProductToBundle.FindAsync(id);
            if (productToBundle == null)
            {
                return HttpNotFound();
            }
            return View(productToBundle);
        }

        // POST: ProductToBundles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ProductToBundle productToBundle = await db.ProductToBundle.FindAsync(id);
            db.ProductToBundle.Remove(productToBundle);
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
