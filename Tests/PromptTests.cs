using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using AddressBook.Core;

namespace AddressBook.Tests
{
    public class PromptTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NullOrEmptyStringCheckPassesIfNotNullOrEmpty()
        {
            var prompt = new Prompt();
            string? testCase = "abc";
            var response = prompt.NullOrEmptyStringCheck(testCase);
            Assert.That(response); // this would equate to true
        }

        [Test]
        public void TestCharactersForbiddenInNamesAreRejected()
        {
            string[] specialCharsAndPunctuation = {
                "!", "\"", "#", "$", "%", "&", "'", "(", ")", "*", "+", ",", "-", ".", "/",
                ":", ";", "<", "=", ">", "?", "@", "[", "\\", "]", "^", "_", "`", "{", "|", "}", "~"
            };
            var prompt = new Prompt();
            foreach (var character in specialCharsAndPunctuation) {
                if (character == "-" || character == "\'") continue;
                var response = prompt.NameCheck($"abc{character}def");
                Assert.That(!response.success, $"Character {character} incorrectly passed {nameof(Prompt.NameCheck)}");
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

            var prompt = new Prompt();
            foreach (string item in honorifics)
            {
                var response = prompt.NameCheck(item);
                Assert.That(!response.success, $"The list of honorfics do not match. The name {item} was not found in the code that was being tested");
            }
        }

        [Test]
        public void NullCheckFailsIfNull()
        {
            var prompt = new Prompt();
            string? testCase = null;
            var response = prompt.NullOrEmptyStringCheck(testCase);
            Assert.That(!response);
        }

        [Test]
        public void EmptyStringCheckFailsIfEmpty()
        {
            var prompt = new Prompt();
            string? testCase = "";
            var response = prompt.NullOrEmptyStringCheck(testCase);
            Assert.That(!response);
        }

        [Test]
        public void NumCheckPassesNumericsOnly()
        {
            var prompt = new Prompt();
            var testCase = "1234567890";
            var response = prompt.NumCheck(testCase);
            Assert.That(testCase == response);
        }

        [Test]
        public void NumCheckPassesNegativeNumerics()
        {
            var prompt = new Prompt();
            var testCase = "-100";
            var response = prompt.NumCheck(testCase);
            Assert.That(testCase == response);
        }

        [Test]
        public void NumCheckFailsNonNumericsOnly()
        {
            var prompt = new Prompt();
            var testCase = "abc";
            var response = prompt.NumCheck(testCase);
            Assert.That(testCase != response);
        }

        [Test]
        public void NumCheckFailsMixedInput()
        {
            var prompt = new Prompt();
            var testCase = "abc123";
            var response = prompt.NumCheck(testCase);
            Assert.That(testCase != response);
        }
    }
}