using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models;

namespace JournalSystemMVC.DataAccessLayer
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository()
        {
            _context = new ApplicationDbContext();
        }

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Address> GetAddresses()
        {
            return _context.Addresses;
        }
    }
}
