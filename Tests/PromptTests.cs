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