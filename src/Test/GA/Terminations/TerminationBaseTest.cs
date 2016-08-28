using System;
using CoolNameGenerator.GA.Terminations;
using NUnit.Framework;
using Rhino.Mocks;
using TestSharp;

namespace Test.GA.Terminations
{
    [TestFixture()]
    [Category("Terminations")]
    public class TerminationBaseTest
    {
        [Test()]
        public void HasReached_NullGeneration_Exception()
        {
            var target = MockRepository.GenerateStub<TerminationBase>();

            ExceptionAssert.IsThrowing(new ArgumentNullException("geneticAlgorithm"), () =>
            {
                target.HasReached(null);
            });
        }
    }
}

