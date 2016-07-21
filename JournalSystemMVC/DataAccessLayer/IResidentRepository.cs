using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.People;

namespace JournalSystemMVC.DataAccessLayer
{
    public interface IResidentRepository : IDisposable
    {
        IEnumerable<Resident> GetResidents();
        Resident GetResidentById(int id);
        Resident GetResidentByJournalId(int journalId);
        void AddResident(Resident resident);
        void DeleteResident(int id);
        void EditResident(Resident resident);
        void Save();
    }
}
