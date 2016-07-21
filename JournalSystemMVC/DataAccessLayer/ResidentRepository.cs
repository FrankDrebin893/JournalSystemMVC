using JournalSystemMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models.People;
using System.Data.Entity;

namespace JournalSystemMVC.DataAccessLayer
{
    public class ResidentRepository : IResidentRepository
    {
        private readonly ApplicationDbContext _context;

        public ResidentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddResident(Resident resident)
        {
            _context.Residents.Add(resident);
        }

        public void DeleteResident(int id)
        {
            var resident = _context.Residents.Find(id);
            _context.Residents.Remove(resident);
        }

        public void EditResident(Resident resident)
        {
            _context.Entry(resident).State = EntityState.Modified;
            _context.Entry(resident.Address).State = EntityState.Modified;
            _context.Entry(resident.ContactInformation).State = EntityState.Modified;
        }

        public Resident GetResidentById(int id)
        {
            return _context.Residents.Include(r => r.Address).Include(r => r.ContactInformation).Include(r => r.Journal).FirstOrDefault(r => r.ResidentId == id);
        }

        public Resident GetResidentByJournalId(int journalId)
        {
            return _context.Residents.Include(r => r.Address).Include(r => r.ContactInformation).Include(r => r.Journal).FirstOrDefault(r => r.JournalId == journalId);
        }

        public IEnumerable<Resident> GetResidents()
        {
            return _context.Residents.ToList();
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
