using NUnit.Framework;
using System;

namespace ParanthesisMatching
{
    public class Tests
    {
        private ParanthesisMatching ParanthesisMatchingService;
        [SetUp]
        public void Setup()
        {
            ParanthesisMatchingService = new ParanthesisMatching();
        }

        [Test]
        public void Test_ParanthesisMatching()
        {
            Assert.IsTrue(ParanthesisMatchingService.MatchParanthesis("{{{[]([])}[]}}"));
        }

        [Test]
        public void Test_ParanthesisMatchingWrong()
        {
            Assert.IsFalse(ParanthesisMatchingService.MatchParanthesis("{{[]}}{"));
        }

        [Test]
        public void Test_ParanthesisMatchingWrong2()
        {
            Assert.IsFalse(ParanthesisMatchingService.MatchParanthesis("{{[]}]"));
        }

        [Test]
        public void Test_ParanthesisMatchingInvalidChars()
        {
            Assert.Throws<ArgumentException>(() => ParanthesisMatchingService.MatchParanthesis("{{[09]}}"));
        }
    }
}