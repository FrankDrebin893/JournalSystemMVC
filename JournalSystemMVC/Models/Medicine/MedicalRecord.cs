using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JournalSystemMVC.Models.CustomModelAttributes;
using JournalSystemMVC.Models.ModelValidationAttributes;
using JournalSystemMVC.Models.People;
using JournalSystemMVC.Models.ResidentData;

namespace JournalSystemMVC.Models.Medicine
{
    public class MedicalRecord
    {
        public MedicalRecord()
        {
            Created = DateTime.Now;
            Prescriptions = new List<PrescriptionMedicine>();
        }

        [Key]
        public int MedicalRecordId { get; set; }
        [ForeignKey("MedicalRecordOwnerResident")]
        public int MedicalRecordOwnerResidentId { get; set; }
        [ForeignKey("AdministeringDoctor")]
        public int AdministeringDoctorId { get; set; }

        [DoubleDecimalValidation]
        public double? Weight { get; set; }
        [DoubleDecimalValidation]
        public double? Height { get; set; }
        [DoubleDecimalValidation]
        public double? WaistLine { get; set; }
        [EuropeanDateFormatDisplay]
        public DateTime Created { get; set; }
        
        public Contact AdministeringDoctor { get; set; }
        public ICollection<PrescriptionMedicine> Prescriptions { get; set; }
        public ICollection<ProReNataMedicine> PrnMedicines { get; set; }
        public Resident MedicalRecordOwnerResident { get; set; }
    }
}
