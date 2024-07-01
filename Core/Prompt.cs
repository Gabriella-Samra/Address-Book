using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Core

// TODO: Clean data so there are no trailing Whitespace
// TODO: If there are more than 1 spaces between words then reduce to just 1 character 

{
    public class Prompt
    {
        public string NullCheck(string response)
        {
            if (response == null)
            {
                //TODO: turn null return into an exception
                return "Your response cannot be null";
            }

            if (response == "")
            {
                //TODO: turn empty return into an exception
                return "Your response cannot be empty";
            }

            else return response;
        }

        public string NameCheck(string response)
        {
            // TODO: Names can't have numbers (UK Guidelines)
            // TODO: Names can't have punctionation marks EXCEPT hyphens and apostrophes (UK Guidelines)
            // TODO: Names can't have special characters eg. @ # ! (UK Guidelines)
            // TODO: Names can't be misleading eg. Sir, Dr.(UK Guidelines)
            // TODO: max length 50 characters? 

            return response;
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