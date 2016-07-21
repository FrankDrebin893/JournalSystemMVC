using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.ResidentData;

namespace JournalSystemMVC.DataAccessLayer
{
    public interface IJournalRepository : IDisposable
    {
        IEnumerable<Journal> GetJournals();
        Journal GetJournalById(int id);
        void EditJournal(Journal journal);
        IEnumerable<JournalEntry> GetJournalEntries();
        IEnumerable<JournalEntry> GetJournalEntriesById(int journalId);
        JournalEntry GetJournalEntryById(int id);
        void AddJournalEntry(JournalEntry journalEntry);
        void DeleteJournalEntry(int id);
        void EditJournalEntry(JournalEntry journalEntry);
        void Save();
    }
}
