// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Runtime.CompilerServices;
using AddressBook.Core;
using AddressBook.Core.Data;

Console.WriteLine("What action do you want to do? Reply with \"Enter\" to enter an item to the address book, \"Find\" to search for a specific entry, and \"Exit\" to exit the program");
var promptForWhichActionToTake = Console.ReadLine();

Prompt.PromptForOptionValidator(promptForWhichActionToTake, new MemoryStore());