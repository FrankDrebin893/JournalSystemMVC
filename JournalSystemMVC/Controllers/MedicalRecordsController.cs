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
using JournalSystemMVC.Models.Medicine;
using EntityState = System.Data.Entity.EntityState;

namespace JournalSystemMVC.Controllers
{
    public class MedicalRecordsController : Controller
    {

        private readonly IMedicineRepository _medicineRepository;

        public MedicalRecordsController()
        {
            _medicineRepository = new MedicineRepository(new ApplicationDbContext());
        }

        public MedicalRecordsController(MedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }
        
        public ActionResult Index()
        {
            return View(_medicineRepository.GetMedicalRecords());
        }
        
        public ActionResult Details(int id)
        {
            MedicalRecord medicalRecord = _medicineRepository.GetMedicalRecordById(id);
            if (medicalRecord == null)
            {
                return HttpNotFound();
            }
            return View(medicalRecord);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedicalRecordId,Weight,Height,WaistLine,Created")] MedicalRecord medicalRecord)
        {
            if (ModelState.IsValid)
            {
                _medicineRepository.AddMedicalRecord(medicalRecord);
                _medicineRepository.Save();
                return RedirectToAction("Index");
            }

            return View(medicalRecord);
        }
        
        public ActionResult Edit(int id)
        {
            MedicalRecord medicalRecord = _medicineRepository.GetMedicalRecordById(id);
            if (medicalRecord == null)
            {
                return HttpNotFound();
            }
            return View(medicalRecord);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicalRecordId,Weight,Height,WaistLine,Created")] MedicalRecord medicalRecord)
        {
            if (ModelState.IsValid)
            {
                _medicineRepository.EditMedicalRecord(medicalRecord);
                _medicineRepository.Save();
                return RedirectToAction("Index");
            }
            return View(medicalRecord);
        }
        
        public ActionResult Delete(int id)
        {
            MedicalRecord medicalRecord = _medicineRepository.GetMedicalRecordById(id);
            if (medicalRecord == null)
            {
                return HttpNotFound();
            }
            return View(medicalRecord);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _medicineRepository.DeleteMedicalRecord(id);
            _medicineRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _medicineRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
