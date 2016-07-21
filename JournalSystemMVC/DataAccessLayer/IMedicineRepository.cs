using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.Medicine;

namespace JournalSystemMVC.DataAccessLayer
{
    // This repository handles CRUD functionality for MedicalRecords along with its foreign key properties like pro re nata medicine and prescriptions.
    public interface IMedicineRepository : IDisposable
    {
        IEnumerable<MedicalRecord> GetMedicalRecords();
        MedicalRecord GetMedicalRecordById(int id);
        void AddMedicalRecord(MedicalRecord medicalRecord);
        void DeleteMedicalRecord(int id);
        void EditMedicalRecord(MedicalRecord medicalRecord);

        void DeleteProReNataMedicine(int id);
        void EditProReNataMedicine(ProReNataMedicine prnMedicine);

        void DeletePrescriptionMedicine(int id);
        void EditPrescriptionMedicine(PrescriptionMedicine prescriptionMedicine);

        void Save();
    }
}
