// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Runtime.CompilerServices;
using AddressBook.Core;

Prompt.PromptForAnswer("What is your first name?", PromptValidationType.FirstName);
Prompt.PromptForAnswer("What is your last name?", PromptValidationType.LastName);
Prompt.PromptForAnswer("What is your main telephone number?", PromptValidationType.PhoneNumber);
Prompt.PromptForAnswer("What is your email address?", PromptValidationType.Email);