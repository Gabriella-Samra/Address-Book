using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using AddressBook.Core;

namespace AddressBook.Tests
{
    public class PromptValidationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        // [Test]
        // public void AssertNoExceptionThrownOnValidStringCheck()
        // {
        //     Exception caught = null;
        //     try
        //     {
        //         var prompt = new Prompt();
        //         string? testCase = "abc";
        //         var response = prompt.NullOrEmptyStringCheck(testCase);
        //     }
        //     catch (Exception e)
        //     {
        //         caught = e;
        //     }
        //     Assert.That(caught == null); // this would equate to true
        // }

        [Test]
        public void NullOrEmptyStringCheckPassesIfNotNullOrEmpty()
        {
            string? testCase = "abc";
            var response = PromptValidation.NullOrEmptyStringCheck(testCase);
            Assert.That(response); // this would equate to true
        }

        [Test]
        public void TestCharactersForbiddenInNamesAreRejected()
        {
            string[] specialCharsAndPunctuation = {
                "!", "\"", "#", "$", "%", "&", "'", "(", ")", "*", "+", ",", "-", ".", "/",
                ":", ";", "<", "=", ">", "?", "@", "[", "\\", "]", "^", "_", "`", "{", "|", "}", "~"
            };
            foreach (var character in specialCharsAndPunctuation)
            {
                if (character == "-" || character == "\'") continue;
                var response = PromptValidation.NameCheck($"abc{character}def");
                Assert.That(!response.success, $"Character {character} incorrectly passed {nameof(PromptValidation.NameCheck)}");
            }
        }

        [Test]
        public void HonorificsAsTheNameAreCaught()
        {
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
                var response = PromptValidation.NameCheck(item);
                Assert.That(!response.success, $"The list of honorfics do not match. The name {item} was not found in the code that was being tested");
            }
        }

        [Test]
        public void NullCheckFailsIfNull()
        {
            string? testCase = null;
            var response = PromptValidation.NullOrEmptyStringCheck(testCase);
            Assert.That(!response);
        }

        [Test]
        public void EmptyStringCheckFailsIfEmpty()
        {
            string? testCase = "";
            var response = PromptValidation.NullOrEmptyStringCheck(testCase);
            Assert.That(!response);
        }

        [Test]
        public void NumCheckPassesNumericsOnly()
        {
            var testCase = "1234567890";
            var response = PromptValidation.NumCheck(testCase);
            Assert.That(response.success);
        }

        // TODO: Implement how to parse negative numbers if needed
        // [Test]
        // public void NumCheckPassesNegativeNumerics()
        // {
        //     var prompt = new Prompt();
        //     var testCase = "-100";
        //     var response = prompt.NumCheck(testCase);
        //     Assert.That(testCase == response);
        // }

        [Test]
        public void NumCheckFailsNonNumericsOnly()
        {
            var testCase = "abc";
            var response = PromptValidation.NumCheck(testCase);
            Assert.That(!response.success);
        }

        [Test]
        public void NumCheckFailsMixedInput()
        {
            var testCase = "abc123";
            var response = PromptValidation.NumCheck(testCase);
            Assert.That(!response.success);
        }

        [Test]
        public void CheckForOneAtSymbolInEmail()
        {
            var testCase = "testCase@test.com";
            var response = PromptValidation.EmailValidationCheck(testCase);
            Assert.That(response.success);
        }

        [Test]
        public void CheckMoreThanOneAtSymbolIsFlagged()
        {
            var testCase = "testCase@te@st.com";
            var response = PromptValidation.EmailValidationCheck(testCase);
            Assert.That(!response.success);
        }

        [Test]
        public void CheckAtSignAtBeginningOfAddressIsFlagged()
        {
            var testCase = "@test.com";
            var response = PromptValidation.EmailValidationCheck(testCase);
            Assert.That(!response.success);
        }

        [Test]
        public void CheckForOneDotSymbolInEmail()
        {
            var testCase = "testCase@test.com";
            var response = PromptValidation.EmailValidationCheck(testCase);
            Assert.That(response.success);
        }

        [Test]
        public void CheckDotSymbolDirectlyAfterAtSymbolIsFlagged()
        {
            var testCase = "testCase@.com";
            var response = PromptValidation.EmailValidationCheck(testCase);
            Assert.That(!response.success);
        }

        [Test]
        public void CheckLessThanTwoCharactersAfterDotIsFlagged()
        {
            var testCase = "testCase@test.c";
            var response = PromptValidation.EmailValidationCheck(testCase);
            Assert.That(!response.success);
        }
    }
}