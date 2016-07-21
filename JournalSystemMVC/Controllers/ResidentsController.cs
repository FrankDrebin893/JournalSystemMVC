using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JournalSystemMVC.Models;
using JournalSystemMVC.Models.People;
using JournalSystemMVC.DataAccessLayer;
using JournalSystemMVC.Models.ResidentData;
using JournalSystemMVC.Models.ViewModels;

namespace JournalSystemMVC.Controllers
{
    public class ResidentsController : Controller
    {
        private readonly IResidentRepository _residentRepository;
        private readonly IJournalRepository _journalRepository;


        public ResidentsController()
        {
            _residentRepository = new ResidentRepository(new ApplicationDbContext());
            _journalRepository = new JournalRepository(new ApplicationDbContext());
        }

        public ResidentsController(IResidentRepository residentRepository)
        {
            _residentRepository = residentRepository;
        }
        
        public ActionResult Index()
        {
            return View(_residentRepository.GetResidents());
        }
        
        public ActionResult Details(int id)
        {
            Resident resident = _residentRepository.GetResidentById(id);
            resident.Journal = _journalRepository.GetJournalById(resident.JournalId);
            if(resident.Journal.JournalEntries != null) resident.Journal.JournalEntries = resident.Journal.JournalEntries.Reverse().ToList();
            return View(resident);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResidentId,JournalId,CivilStatus,OfAge,PayingMunicipality,ActingMunicipality,BirthPlace,MovedIn,AddressId,ContactInformationId,FirstName,LastName,SocialSecurityNumber,DateOfBirth,Registered,Gender")] Resident resident, HttpPostedFileBase upload)
        {
            resident.Registered = DateTime.Now;
            resident.Address = new Address();
            resident.ContactInformation = new ContactInformation();
            //resident.Journal = new Journal();

            if (upload != null && upload.ContentLength > 0)
            {
                var reader = new System.IO.BinaryReader(upload.InputStream);
                byte[] avatar = reader.ReadBytes(upload.ContentLength);
                resident.Avatar = avatar;
            }

            if (ModelState.IsValid)
            {
                _residentRepository.AddResident(resident);
                _residentRepository.Save();
                return RedirectToAction("Index");
            }

            return View(resident);
        }
        
        public ActionResult Edit(int id)
        {
            var resident = _residentRepository.GetResidentById(id);
            return View(resident);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResidentId,JournalId, Avatar, Address,ContactInformation,CivilStatus,OfAge,PayingMunicipality,ActingMunicipality,BirthPlace,MovedIn,AddressId,ContactInformationId,FirstName,LastName,SocialSecurityNumber,DateOfBirth,Registered,Gender")] Resident resident, HttpPostedFileBase upload)
        {

            if (upload != null && upload.ContentLength > 0)
            {
                var reader = new System.IO.BinaryReader(upload.InputStream);
                byte[] avatar = reader.ReadBytes(upload.ContentLength);
                resident.Avatar = avatar;
            }

            if (ModelState.IsValid)
            {
                _residentRepository.EditResident(resident);
                _residentRepository.Save();
                return RedirectToAction("Index");
            }
            return View(resident);
        }
        
        public ActionResult Delete(int id)
        {
            var resident = _residentRepository.GetResidentById(id);
            return View(resident);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var resident = _residentRepository.GetResidentById(id);
            _residentRepository.DeleteResident(id);
            _residentRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _residentRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
