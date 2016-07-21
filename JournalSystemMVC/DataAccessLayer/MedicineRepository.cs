using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models;
using JournalSystemMVC.Models.Medicine;

namespace JournalSystemMVC.DataAccessLayer
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MedicalRecord> GetMedicalRecords()
        {
            return _context.MedicalRecords.ToList();
        }

        public MedicalRecord GetMedicalRecordById(int id)
        {
            return _context.MedicalRecords.Include(m => m.Prescriptions).Include(m => m.PrnMedicines).Include(m => m.AdministeringDoctor).Include(m => m.AdministeringDoctor.Address).Include(m => m.AdministeringDoctor.ContactInformation).FirstOrDefault(m => m.MedicalRecordId == id);
        }

        public void AddMedicalRecord(MedicalRecord medicalRecord)
        {
            _context.MedicalRecords.Add(medicalRecord);
        }

        public void DeleteMedicalRecord(int id)
        {
            var record = GetMedicalRecordById(id);
            _context.MedicalRecords.Remove(record);
        }

        public void EditMedicalRecord(MedicalRecord medicalRecord)
        {
            _context.Entry(medicalRecord).State = EntityState.Modified;
            _context.Entry(medicalRecord.Prescriptions).State = EntityState.Modified;
            _context.Entry(medicalRecord).State = EntityState.Modified;
        }

        public void DeleteProReNataMedicine(int id)
        {
            var prnMedicine = _context.PrnMedicines.Find(id);
            _context.PrnMedicines.Remove(prnMedicine);
        }

        public void EditProReNataMedicine(ProReNataMedicine prnMedicine)
        {
            _context.Entry(prnMedicine).State = EntityState.Modified;
        }

        public void DeletePrescriptionMedicine(int id)
        {
            var prescription = _context.Prescriptions.Find(id);
            _context.Prescriptions.Remove(prescription);
        }

        public void EditPrescriptionMedicine(PrescriptionMedicine prescriptionMedicine)
        {
            _context.Entry(prescriptionMedicine).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
