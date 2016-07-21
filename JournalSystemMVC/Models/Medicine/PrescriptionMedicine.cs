using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JournalSystemMVC.Models.Medicine
{
    public class PrescriptionMedicine : Medicine
    {
        [Key]
        public int PrescriptionMedicineId { get; set; }
        public virtual ICollection<MedicineAdministrationTime> AdministrationTimes { get; set; }
    }
}
