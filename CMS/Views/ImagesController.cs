﻿using System;
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
    public class ImagesController : Controller
    {
        private ECommerce db = new ECommerce();

        // GET: Images
        public async Task<ActionResult> Index()
        {
            var image = db.Image.Include(i => i.ImageType);
            return View(await image.ToListAsync());
        }

        // GET: Images/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = await db.Image.FindAsync(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // GET: Images/Create
        public ActionResult Create()
        {
            ViewBag.ImageTypeId = new SelectList(db.ImageType, "Id", "Name");
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,ImageTypeId,URL,Base64")] Image image)
        {
            if (ModelState.IsValid)
            {
                image.Id = Guid.NewGuid();
                db.Image.Add(image);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ImageTypeId = new SelectList(db.ImageType, "Id", "Name", image.ImageTypeId);
            return View(image);
        }

        // GET: Images/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = await db.Image.FindAsync(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewBag.ImageTypeId = new SelectList(db.ImageType, "Id", "Name", image.ImageTypeId);
            return View(image);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,ImageTypeId,URL,Base64")] Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ImageTypeId = new SelectList(db.ImageType, "Id", "Name", image.ImageTypeId);
            return View(image);
        }

        // GET: Images/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = await db.Image.FindAsync(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Image image = await db.Image.FindAsync(id);
            db.Image.Remove(image);
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