using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AddressBook.Core

{
    public static class PromptValidation
    {
        public static bool NullOrEmptyStringCheck(string? response)
        {
            return !string.IsNullOrEmpty(response);
        }

        public static (bool success, string message) NameValidationCheck(string response)
        {         
            // Max length 150 characters incl. white spaces across all your names. Documentation allow only 30 characters in a first name
            if (response.Length > 30)
            {
                return (false, $"Your name can only have 30 characters according to UK guidelines. The length of your name was {response.Length}");
            }

            foreach (char character in response)
            {
                // Names can't have numbers (UK Guidelines)
                if (char.IsDigit(character))
                {
                    return (false, $"You cannot have numbers in your name according to UK law, the character that was flagged was {character}");
                }
                
                // Names can't have punctionation marks EXCEPT hyphens and apostrophes (UK Guidelines)
                var isSpecialChar = char.IsPunctuation(character);
                var isPermittedSpecialCharacter = isSpecialChar && (character == '-' || character == '\'');

                if (isSpecialChar && !isPermittedSpecialCharacter) 
                {
                    return (false, $"You cannot have {character} in your name according to UK law");
                }
                
                // Names can't have special characters eg. @ # (UK Guidelines)
                if (char.IsSymbol(character)) 
                {
                    return (false, $"You cannot have {character} in your name according to UK law");
                }
            }

            // Names can't be misleading eg. Sir, Dr.(UK Guidelines)
            List<string> honorifics = 
                [
                "Sir", 
                "Lord", 
                "Laird", 
                "Lady", 
                "Prince", 
                "Princess", 
                "Viscount", 
                "Baron", 
                "Baroness", 
                "General", 
                "Captain", 
                "Professor",
                "Doctor",
                "Dr"
                ];

            foreach (string item in honorifics)
            {
                if (response == item)
                {
                    return (false, $"You cannot have {item} as your name according to UK law as it can be misleading");
                }
            }

            return (true, "This name is allowed");
        }

        public static (bool success, string message) NumberValidationCheck (string response)
        {
            foreach (char character in response)
            {
                var characterCandidate = (int)char.GetNumericValue(character);
                if (characterCandidate == -1)
                {
                    return (false, "Your response must contain only numbers");
                }
            }
            return (true, response);

        }

        public static (bool success, string message) EmailValidationCheck (string response)
        {
            int atSymbolCounter = 0;
            int atSymbolIndexPosition = -1;
            int dotSymbolIndexPosition = response.Length;
            int dotSymbolCounter = 0;

            // must have an @ symbol
            for (int i = 0; i < response.Length; i++)
            {
                if (response[i] == '@')
                {
                    atSymbolCounter += 1;
                    atSymbolIndexPosition = i;

                    if (atSymbolCounter > 1)
                    {
                        return (false, "There is more than 1 @ symbol in the email address");
                    }
                }
            }

            if (atSymbolCounter == 0)
            {
                return (false, "There is no @ symbol in the email address");
            }

            // must have characters before the @
            if (atSymbolIndexPosition == 0)
            {
                return (false, "The @ symbol needs to be after a minimum of 1 character");
            }

            for (int i = atSymbolIndexPosition; i < response.Length; i++)
            {
                if (response[i] == '.')
                {
                    dotSymbolCounter ++;
                    dotSymbolIndexPosition = i;
                }
            }

            if (dotSymbolCounter == 0)
            {
                return (false, "There needs to be a minimum of 1 . symbol");
            }

            // must have a valid domain name where you have minimum 1 character followed by a . 
            if (response[atSymbolIndexPosition + 1] == '.')
            {
                return (false, "There needs to be a minimum of 1 character between the @ and . symbols");
            }
            
            // must hace a min 2 characters after the . in the domain part
            if (((response.Length - 1) - dotSymbolIndexPosition) < 2)
            {
                return (false, "There must be a minimum of 2 characters after the . symbol");
            }

            return (true, response);
        }
    }
}