using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using AddressBook.Core.Data;

namespace AddressBook.Core

// TODO: Clean data so there are no trailing Whitespace
// TODO: If there are more than 1 spaces between words then reduce to just 1 character 

{
    public enum PromptValidationType
    {
        Name,
        PhoneNumber,
        Email
    }

    public static class Prompt
    {
        public static void PromptForOptionValidator(string? chosenOption, IAddressBookStore addressBookWriter)
        {
            //TODO: Make the options not case sensitive

            while (true)
            {
                // Make this into a switch
                if (chosenOption == "Enter")
                {
                    AddAnEntry(addressBookWriter);
                }

                if (chosenOption == "Find")
                {
                    SearchForAnEntry(addressBookWriter);
                }

                if (chosenOption == "Exit")
                {
                    Console.WriteLine("Okay, exiting the program now");
                    Environment.Exit(0);
                }

                else 
                {
                    Console.WriteLine("Please choose one of the following options: \"Enter\" to enter an item to the address book, \"Find\" to search for a specific entry, and \"Exit\" to exit the program");
                    var promptForWhichActionToTake = Console.ReadLine();
                    Prompt.PromptForOptionValidator(promptForWhichActionToTake, addressBookWriter);
                }
            }
            
        }

        private static void AddAnEntry(IAddressBookStore addressBookWriter)
        {
            var firstName = Prompt.PromptForAnswer("What is your first name?", PromptValidationType.Name);
            var lastName = Prompt.PromptForAnswer("What is your last name?", PromptValidationType.Name);
            var number = Prompt.PromptForAnswer("What is your main telephone number?", PromptValidationType.PhoneNumber);
            var email = Prompt.PromptForAnswer("What is your email address?", PromptValidationType.Email);
            addressBookWriter.Write(new List<AddressBookItem> { new AddressBookItem { FirstName = firstName, LastName = lastName, Email = email, PhoneNumber = number } });
        }

        private static void SearchForAnEntry(IAddressBookStore addressBookReader)
        {
            var request = Prompt.PromptForAnswer("What is the name of the person's details are you looking for?", PromptValidationType.Name);
            var matchedNames = addressBookReader.Read(request);

            foreach (var item in matchedNames)
            {
                Console.WriteLine($"New Record found: \n Name: {item.FirstName} {item.LastName} \n Tel number: {item.PhoneNumber} \n Email address: {item.Email}");
            }
        }

        public static string PromptForAnswer(string question, PromptValidationType validationType)
        {
            (bool success, string? message) validatedResponse = (false, "initial message");

            string? response = "";

            while (validatedResponse.success == false)
            {
                Console.WriteLine(question);
                response = Console.ReadLine();
                validatedResponse = ValidatePrompt(validationType, response ?? "");

                if (validatedResponse.success == false)
                {
                    Console.WriteLine($"{validatedResponse.message}, please try again");
                }
                else
                {
                    Console.WriteLine($"Recognised input: {response}");
                }
            }

            return response;
        }

        private static (bool success, string? message) ValidatePrompt(PromptValidationType validationType, string response)
        {
            var doesTheResponseHaveContent = PromptValidation.NullOrEmptyStringCheck(response);

            if (!doesTheResponseHaveContent)
            {
                return (false, "You must give an answer");
            }

            switch (validationType)
            {
                case PromptValidationType.Name: return PromptValidation.NameValidationCheck(response);
                case PromptValidationType.PhoneNumber: return PromptValidation.NumberValidationCheck(response);
                case PromptValidationType.Email: return PromptValidation.EmailValidationCheck(response);
                default: throw new NotImplementedException($"Cannot handle validation type {validationType}");
            }
        }
    }
}