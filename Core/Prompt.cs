using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AddressBook.Core

// TODO: Clean data so there are no trailing Whitespace
// TODO: If there are more than 1 spaces between words then reduce to just 1 character 

{
    public class Prompt
    {
        public bool NullOrEmptyStringCheck(string? response)
        {
            if (response == null || response == "")
            {
                return false;
            }

            else return true;
        }

        public (bool success, string message) NameCheck(string response)
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


        public string NumCheck (string response)
        {
            foreach (char character in response)
            {
                var characterCandidate = (int)char.GetNumericValue(character);
                if (characterCandidate == -1)
                {
                    //TODO: turn only numbers return into an exception
                    return "Your response must contain only numbers";
                }
            }
            return response;

            // TODO: think about how to deal with +area codes
            // TODO: think about valid number of characters to make it a geniuene number
        }

        public string EmailCheck (string response)
        {
            // TODO: must have an @ symbol
            // TODO: must have characters before the @
            // TODO: must have a valid domain name where you have minimum 1 character followed by a . 
            // TODO: must hace a min 2 characters after the . in the domain part



            return response;
        }

    }

}