using System;
using System.Collections.Generic;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Crossovers;
using NUnit.Framework;
using Rhino.Mocks;
using TestSharp;

namespace Test.GA.Crossovers
{
    [TestFixture]
    [Category("Crossovers")]
    public class CrossoverBaseTest
    {
        [Test]
        public void Cross_Null_Exception()
        {
            var target = MockRepository.GeneratePartialMock<CrossoverBase>(2, 2);

            ExceptionAssert.IsThrowing(new ArgumentNullException("parents"), () =>
            {
                target.Cross(null);
            });
        }

        [Test]
        public void Cross_InvalidNumberOfParents_Exception()
        {
            var target = MockRepository.GeneratePartialMock<CrossoverBase>(2, 2);

            ExceptionAssert.IsThrowing(new ArgumentOutOfRangeException("parents", "The number of parents should be the same of ParentsNumber."), () =>
            {
                target.Cross(new List<IChromosome>());
            });

            ExceptionAssert.IsThrowing(new ArgumentOutOfRangeException("parents", "The number of parents should be the same of ParentsNumber."), () =>
            {
                target.Cross(new List<IChromosome>() { MockRepository.GenerateMock<IChromosome>() });
            });
        }
    }
}