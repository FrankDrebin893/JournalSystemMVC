using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JournalSystemMVC.DataAccessLayer;
using JournalSystemMVC.Models;
using JournalSystemMVC.Models.ResidentData;
using JournalSystemMVC.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JournalSystemMVC.Controllers
{
    public class JournalsController : Controller
    {
        private readonly IJournalRepository _journalRepository;
        private readonly IResidentRepository _residentRepository;

        public JournalsController()
        {
            _journalRepository = new JournalRepository(new ApplicationDbContext());
            _residentRepository = new ResidentRepository(new ApplicationDbContext());
        }

        public JournalsController(IJournalRepository repository)
        {
            _journalRepository = repository;
        }
        
        public ActionResult Index()
        {
            return View(_journalRepository.GetJournals());
        }
        
        public ActionResult Details(int id)
        {
            /*Journal journal = _journalRepository.GetJournalById(id);
            if (journal == null)
            {
                return HttpNotFound();
            }*/

            JournalViewModel journalVm = new JournalViewModel()
            {
                Journal = _journalRepository.GetJournalById(id),
                JournalEntries = _journalRepository.GetJournalEntriesById(id)
            };

            var resident = _residentRepository.GetResidentByJournalId(journalVm.Journal.JournalId);
            journalVm.ResidentName = resident.FirstName + " " + resident.LastName;
            journalVm.ResidentId = journalVm.Journal.JournalId;
            return View(journalVm);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateEntry(int id)
        {
            var journalEntryVm = new JournalEntryViewModel();
            journalEntryVm.JournalId = id;
            return View(journalEntryVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEntry([Bind(Include = "JournalId, JournalEntry")] JournalEntryViewModel journalEntryVm)
        {
            journalEntryVm.JournalEntry.EntryDate = DateTime.Now;
            journalEntryVm.JournalEntry.AuthorId = 1;
            var journal = _journalRepository.GetJournalById(journalEntryVm.JournalId);
            journal.JournalEntries.Add(journalEntryVm.JournalEntry);

            if (ModelState.IsValid)
            {
                _journalRepository.EditJournal(journal);
                _journalRepository.Save();
            }

            return RedirectToAction("Details", new {id = journalEntryVm.JournalId});
        }
        
        public ActionResult Edit(int id)
        {

            Journal journal = _journalRepository.GetJournalById(id);
            if (journal == null)
            {
                return HttpNotFound();
            }
            return View(journal);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JournalId,ProfileDescription")] Journal journal)
        {
            if (ModelState.IsValid)
            {
                _journalRepository.EditJournal(journal);
                _journalRepository.Save();
                return RedirectToAction("Index");
            }
            return View(journal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEntry([Bind(Include = "JournalId, EntryText")] JournalEntry entry)
        {
            JournalEntry newEntry = entry;
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int authorId = currentUser.EmployeeId;
            newEntry.AuthorId = authorId;

            if (ModelState.IsValid)
            {
                _journalRepository.AddJournalEntry(newEntry);
                _journalRepository.Save();
            }

            return RedirectToAction("Details", new {id = entry.JournalId});
        }

        protected override void Dispose(bool disposing)
        {
            _journalRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
