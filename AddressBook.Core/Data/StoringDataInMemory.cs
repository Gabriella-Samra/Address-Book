using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Core;

namespace AddressBook.Core.Data
{
    public class StoringDataInMemory
    {
        public static List<AddressBookItem>? StoredAddressBookItems {get; private set; } = new List<AddressBookItem>();

        public static void WriteToAddressBook(List<AddressBookItem> addressBookItems)
        {
            StoredAddressBookItems.AddRange(addressBookItems);
        }

        
    }
}