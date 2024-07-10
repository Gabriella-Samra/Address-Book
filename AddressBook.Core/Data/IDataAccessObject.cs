using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AddressBook.Core;

namespace AddressBook.Core.Data
{
    public interface IAddressBookStore
    {
        List<AddressBookItem> Read(string firstName);
        void Write(List<AddressBookItem> items);
    }

    public class MemoryStore : IAddressBookStore
    {
        public List<AddressBookItem> Read(string firstName)
        {
            if (MemoryAddressBookStore.StoredAddressBookItems == null)
            {
                return new List<AddressBookItem>();
            }
            
            return MemoryAddressBookStore.StoredAddressBookItems.Where(item => item.FirstName.Contains(firstName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void Write(List<AddressBookItem> items)
        {
            MemoryAddressBookStore.WriteToAddressBook(items);
        }
    }

    public class DiskStore : IAddressBookStore
    {
        public List<AddressBookItem> Read(string firstName)
        {
            throw new NotImplementedException();
        }

        public void Write(List<AddressBookItem> items)
        {
            throw new NotImplementedException();
        }
    }
}