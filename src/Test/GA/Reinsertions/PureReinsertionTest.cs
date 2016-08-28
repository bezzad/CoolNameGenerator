using System.Collections.Generic;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Populations;
using CoolNameGenerator.GA.Reinsertions;
using NUnit.Framework;
using Rhino.Mocks;

namespace Test.GA.Reinsertions
{
    [TestFixture()]
    [Category("Reinsertions")]
    public class PureReinsertionTest
    {
        [Test()]
        public void SelectChromosomes_offspringSizeEqualsParentsSizeAndGreaterThanMinSizeAndLowerThanMaxSize_Selectoffspring()
        {
            var target = new PureReinsertion();
            var chromosome = MockRepository.GenerateStub<ChromosomeBase>(2);

            var population = new Population(2, 6, chromosome);
            var offspring = new List<IChromosome>() {
                chromosome, chromosome, chromosome, chromosome
            };

            var parents = new List<IChromosome>() {
                MockRepository.GenerateStub<ChromosomeBase> (2),
                MockRepository.GenerateStub<ChromosomeBase> (2),
                MockRepository.GenerateStub<ChromosomeBase> (2),
                MockRepository.GenerateStub<ChromosomeBase> (2)
            };

            var selected = target.SelectChromosomes(population, offspring, parents);
            Assert.AreEqual(4, selected.Count);
            Assert.AreEqual(2, selected[0].Length);
            Assert.AreEqual(2, selected[1].Length);
            Assert.AreEqual(2, selected[2].Length);
            Assert.AreEqual(2, selected[3].Length);
        }
    }
}