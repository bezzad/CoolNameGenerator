using System.Collections.Generic;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Populations;
using CoolNameGenerator.GA.Reinsertions;
using NUnit.Framework;
using Rhino.Mocks;
using TestSharp;

namespace Test.GA.Reinsertions
{
    [TestFixture()]
    [Category("Reinsertions")]
    public class UniformReinsertionTest
    {
        [Test()]
        public void SelectChromosomes_OffspringSizeEqualsZero_Exception()
        {
            var target = new UniformReinsertion();
            var population = new Population(6, 8, MockRepository.GenerateStub<ChromosomeBase>(2));
            var offspring = new List<IChromosome>();

            var parents = new List<IChromosome>() {
                MockRepository.GenerateStub<ChromosomeBase> (5),
                MockRepository.GenerateStub<ChromosomeBase> (6),
                MockRepository.GenerateStub<ChromosomeBase> (7),
                MockRepository.GenerateStub<ChromosomeBase> (8)
            };

            ExceptionAssert.IsThrowing(new ReinsertionException(target, "The minimum size of the offspring is 1."), () =>
            {
                target.SelectChromosomes(population, offspring, parents);
            });
        }

        [Test()]
        public void SelectChromosomes_offspringSizeLowerThanMinSize_Selectoffspring()
        {
            var target = new UniformReinsertion();

            var population = new Population(6, 8, MockRepository.GenerateStub<ChromosomeBase>(2));
            var offspring = new List<IChromosome>() {
                MockRepository.GenerateStub<ChromosomeBase> (2),
                MockRepository.GenerateStub<ChromosomeBase> (2),
                MockRepository.GenerateStub<ChromosomeBase> (3),
                MockRepository.GenerateStub<ChromosomeBase> (4)
            };

            var parents = new List<IChromosome>() {
                MockRepository.GenerateStub<ChromosomeBase> (5),
                MockRepository.GenerateStub<ChromosomeBase> (6),
                MockRepository.GenerateStub<ChromosomeBase> (7),
                MockRepository.GenerateStub<ChromosomeBase> (8)
            };

            var selected = target.SelectChromosomes(population, offspring, parents);
            Assert.AreEqual(6, selected.Count);
            Assert.AreEqual(2, selected[0].Length);
            Assert.AreEqual(2, selected[1].Length);
            Assert.AreEqual(3, selected[2].Length);
            Assert.AreEqual(4, selected[3].Length);
            Assert.AreEqual(2, selected[4].Length);
            Assert.AreEqual(4, selected[5].Length);
        }
    }
}

