// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Runtime.CompilerServices;
using AddressBook.Core;
using AddressBook.Core.Data;

var firstName = Prompt.PromptForAnswer("What is your first name?", PromptValidationType.FirstName);
var lastName = Prompt.PromptForAnswer("What is your last name?", PromptValidationType.LastName);
var number = Prompt.PromptForAnswer("What is your main telephone number?", PromptValidationType.PhoneNumber);
var email = Prompt.PromptForAnswer("What is your email address?", PromptValidationType.Email);
IAddressBookWriter addressBookWriter = new MemoryWriter();
addressBookWriter.Write(new List<AddressBookItem> { new AddressBookItem { FirstName = firstName, LastName = lastName, Email = email, PhoneNumber = number } });