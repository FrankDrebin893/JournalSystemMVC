using System.ComponentModel.DataAnnotations;

namespace JournalSystemMVC.Models.Medicine
{
    public class ProReNataMedicine : Medicine
    {
        [Key]
        public int MedicineProNecessitateId { get; set; }
        public int? MaxTimesPerDay { get; set; }
        [StringLength(40, ErrorMessage = "Side effects description cannot exceed 40 characters.")]
        public string SideEffects { get; set; }
    }
}
