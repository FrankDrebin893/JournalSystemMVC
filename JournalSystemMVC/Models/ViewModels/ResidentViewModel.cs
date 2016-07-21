using JournalSystemMVC.Models.People;

namespace JournalSystemMVC.Models.ViewModels
{
    public class ResidentViewModel
    {
        public Resident Resident { get; set; }
        public Address Address { get; set; }
        public ContactInformation ContactInformation { get; set; }
    }
}
