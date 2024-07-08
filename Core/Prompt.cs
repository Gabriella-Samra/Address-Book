using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace AddressBook.Core

// TODO: Clean data so there are no trailing Whitespace
// TODO: If there are more than 1 spaces between words then reduce to just 1 character 

{
    public class Prompt
    {
        public static void PromptInitialiser(string question)
        {
            (bool success, string? message) response = (false, "initial message");

            while (response.success == false)
            {
                response = Prompt.PromptForResponse($"{question}");

                if (response.success == false)
                {
                    Console.WriteLine($"{response.message}, please try again");
                }
            }

            response = (false, "initial message");
        }

        public static (bool success, string? message) PromptForResponse(string message)
        {
            Console.WriteLine(message);
            string? response = Console.ReadLine();

            // var prompt = new PromptValidation();

            var doesTheResponseHaveContent = PromptValidation.NullOrEmptyStringCheck(response);

            if (!doesTheResponseHaveContent)
            {
                return (false, "You must give an answer");
            }

            if (message.Contains("first"))
            {
                var validationCheck = PromptValidation.NameCheck(response);
                return ValidationChecker(validationCheck, response);
            }

            if (message.Contains("last"))
            {
                var validationCheck = PromptValidation.NameCheck(response);
                return ValidationChecker(validationCheck, response);
            }

            if (message.Contains("number"))
            {
                var validationCheck = PromptValidation.NumCheck(response);
                return ValidationChecker(validationCheck, response);
            }

            if (message.Contains("email"))
            {
                var validationCheck = PromptValidation.EmailValidationCheck(response);
                return ValidationChecker(validationCheck, response);                
            }

            return (true, response); 
        }

        private static (bool success, string message) ValidationChecker ((bool success, string message) validationCheck, string response)
        {
            if (validationCheck.success == false)
                {
                    return (validationCheck.success, validationCheck.message);
                }
            else return (true, response);
        }
    }
}