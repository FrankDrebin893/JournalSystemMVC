using System.ComponentModel.DataAnnotations;

namespace JournalSystemMVC.Models.Medicine
{
    public abstract class Medicine
    {
        [Required]
        public string PreparationName { get; set; }
        public string Description { get; set; }
        public string Dosage { get; set; }
        public string DispenserType { get; set; }
        public string AdministrationReason { get; set; }
    }
}
