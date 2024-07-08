using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Core.Data
{
    public interface IAddressBookWriter
    {
        List<AddressBookItem> Read();
        void Write(List<AddressBookItem> items);
    }

    public class MemoryWriter : IAddressBookWriter
    {
        public List<AddressBookItem> Read()
        {
            throw new NotImplementedException();
        }

        public void Write(List<AddressBookItem> items)
        {
            throw new NotImplementedException();
        }
    }

    public class DiskWriter : IAddressBookWriter
    {
        public List<AddressBookItem> Read()
        {
            throw new NotImplementedException();
        }

        public void Write(List<AddressBookItem> items)
        {
            throw new NotImplementedException();
        }
    }
}