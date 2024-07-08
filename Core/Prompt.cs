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
        public static void PromptForAnswerInitialiser(string question)
        {
            (bool success, string? message) validatedResponse = (false, "initial message");

            while (validatedResponse.success == false)
            {
                validatedResponse = Prompt.PromptForResponse($"{question}");

                if (validatedResponse.success == false)
                {
                    Console.WriteLine($"{validatedResponse.message}, please try again");
                }
            }

            validatedResponse = (false, "initial message");
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
                var resultOfValidationCheck = PromptValidation.NameCheck(response);
                return ValidationChecker(resultOfValidationCheck, response);
            }

            if (message.Contains("last"))
            {
                var resultOfValidationCheck = PromptValidation.NameCheck(response);
                return ValidationChecker(resultOfValidationCheck, response);
            }

            if (message.Contains("number"))
            {
                var resultOfValidationCheck = PromptValidation.NumCheck(response);
                return ValidationChecker(resultOfValidationCheck, response);
            }

            if (message.Contains("email"))
            {
                var resultOfValidationCheck = PromptValidation.EmailValidationCheck(response);
                return ValidationChecker(resultOfValidationCheck, response);                
            }

            return (true, response); 
        }

        private static (bool success, string message) ValidationChecker ((bool success, string message) resultOfValidationCheck, string response)
        {
            if (resultOfValidationCheck.success == false)
                {
                    return (resultOfValidationCheck.success, resultOfValidationCheck.message);
                }
            else return (true, response);
        }
    }
}