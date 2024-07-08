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
    public enum PromptValidationType
    {
        FirstName,
        LastName,
        PhoneNumber,
        Email
    }

    public class Prompt
    {
        public static string PromptForAnswer(string question, PromptValidationType validationType)
        {
            (bool success, string? message) validatedResponse = (false, "initial message");

            string response = "";

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
                case PromptValidationType.FirstName: return PromptValidation.NameCheck(response);
                case PromptValidationType.LastName: return PromptValidation.NameCheck(response);
                case PromptValidationType.PhoneNumber: return PromptValidation.NumCheck(response);
                case PromptValidationType.Email: return PromptValidation.EmailValidationCheck(response);
                default: throw new NotImplementedException($"Cannot handle validation type {validationType}");
            }
        }
    }
}