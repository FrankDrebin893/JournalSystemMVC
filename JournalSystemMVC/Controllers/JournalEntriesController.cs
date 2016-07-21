using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JournalSystemMVC.Models;
using JournalSystemMVC.Models.ResidentData;
using EntityState = System.Data.Entity.EntityState;

namespace JournalSystemMVC.Controllers
{
    public class JournalEntriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JournalEntries
        public ActionResult Index()
        {
            var journalEntries = db.JournalEntries.Include(j => j.Author);
            return View(journalEntries.ToList());
        }

        // GET: JournalEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournalEntry journalEntry = db.JournalEntries.Find(id);
            if (journalEntry == null)
            {
                return HttpNotFound();
            }
            return View(journalEntry);
        }

        // GET: JournalEntries/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Employees, "EmployeeId", "FirstName");
            return View();
        }

        // POST: JournalEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JournalEntryId,AuthorId,EntryText,EntryDate")] JournalEntry journalEntry)
        {
            if (ModelState.IsValid)
            {
                db.JournalEntries.Add(journalEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Employees, "EmployeeId", "FirstName", journalEntry.AuthorId);
            return View(journalEntry);
        }

        // GET: JournalEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournalEntry journalEntry = db.JournalEntries.Find(id);
            if (journalEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Employees, "EmployeeId", "FirstName", journalEntry.AuthorId);
            return View(journalEntry);
        }

        // POST: JournalEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JournalEntryId,AuthorId,EntryText,EntryDate")] JournalEntry journalEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(journalEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Employees, "EmployeeId", "FirstName", journalEntry.AuthorId);
            return View(journalEntry);
        }

        // GET: JournalEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournalEntry journalEntry = db.JournalEntries.Find(id);
            if (journalEntry == null)
            {
                return HttpNotFound();
            }
            return View(journalEntry);
        }

        // POST: JournalEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JournalEntry journalEntry = db.JournalEntries.Find(id);
            db.JournalEntries.Remove(journalEntry);
            db.SaveChanges();
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
