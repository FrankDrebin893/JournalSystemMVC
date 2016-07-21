using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalSystemMVC.Models;

namespace JournalSystemMVC.DataAccessLayer
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAddresses();
    }
}
