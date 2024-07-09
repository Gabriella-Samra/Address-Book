using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AddressBook.Core;

namespace AddressBook.Core.Data
{
    public interface IAddressBookWriter
    {
        List<AddressBookItem> Read(string firstName);
        void Write(List<AddressBookItem> items);
    }

    public class MemoryWriter : IAddressBookWriter
    {
        public List<AddressBookItem> Read(string firstName)
        {
            if (StoringDataInMemory.StoredAddressBookItems == null)
            {
                return new List<AddressBookItem>();
            }

            return StoringDataInMemory.StoredAddressBookItems.Where(item => item.FirstName.Contains(firstName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void Write(List<AddressBookItem> items)
        {
            StoringDataInMemory.WriteToAddressBook(items);
        }
    }

    public class DiskWriter : IAddressBookWriter
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