using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models;
using JournalSystemMVC.Models.ResidentData;
using Microsoft.Ajax.Utilities;

namespace JournalSystemMVC.DataAccessLayer
{
    public class JournalRepository : IJournalRepository
    {
        private readonly ApplicationDbContext _context;

        public JournalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Journal> GetJournals()
        {
            return _context.Journals.ToList();
        } 

        public Journal GetJournalById(int id)
        {
            //return _context.Journals.Where(j => j.JournalId == id).Include(j => j.JournalEntries).FirstOrDefault();
            //return _context.Journals.Find(id);
            return _context.Journals.Include(j => j.JournalEntries.Select(je => je.Author)).FirstOrDefault(j => j.JournalId == id);
        }

        public void EditJournal(Journal journal)
        {
            _context.Journals.Attach(journal);
            _context.Entry(journal).State = EntityState.Modified;
        }

        public IEnumerable<JournalEntry> GetJournalEntries()
        {
            var list = _context.JournalEntries.Include(je => je.Author).ToList();
            list.Reverse();
            return list;
        } 

        public IEnumerable<JournalEntry> GetJournalEntriesById(int journalId)
        {
            var journal = _context.Journals.Where(j => j.JournalId == journalId).Include(j => j.JournalEntries.Select(je => je.Author)).FirstOrDefault();
            return journal.JournalEntries.Reverse().ToList();
        }

        public JournalEntry GetJournalEntryById(int id)
        {
            return _context.JournalEntries.Find(id);
        }

        public void AddJournalEntry(JournalEntry journalEntry)
        {
            _context.JournalEntries.Add(journalEntry);
        }

        public void DeleteJournalEntry(int id)
        {
            var journalEntry = _context.JournalEntries.Find(id);
            _context.JournalEntries.Remove(journalEntry);
        }

        public void EditJournalEntry(JournalEntry journalEntry)
        {
            _context.JournalEntries.Attach(journalEntry);
            _context.Entry(journalEntry).State = EntityState.Modified;
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
