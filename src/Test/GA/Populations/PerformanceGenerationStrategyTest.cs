using System.Collections.Generic;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Populations;
using NUnit.Framework;

namespace Test.GA.Populations
{
    [TestFixture]
    [Category("Populations")]
    public class PerformanceGenerationStrategyTest
    {
        [Test]
        public void RegisterNewGeneration_GenerationDoesNotExceedGenerationsNumber_DoNothing()
        {
            var target = new PerformanceGenerationStrategy(4);
            var population = new Population(2, 6, new ChromosomeStub());

            population.CreateInitialGeneration();
            target.RegisterNewGeneration(population);
            Assert.AreEqual(1, population.Generations.Count);

            population.CreateNewGeneration(new List<IChromosome>() { new ChromosomeStub(), new ChromosomeStub() });
            target.RegisterNewGeneration(population);
            Assert.AreEqual(2, population.Generations.Count);

            population.CreateNewGeneration(new List<IChromosome>() { new ChromosomeStub(), new ChromosomeStub() });
            target.RegisterNewGeneration(population);
            Assert.AreEqual(3, population.Generations.Count);

            population.CreateNewGeneration(new List<IChromosome>() { new ChromosomeStub(), new ChromosomeStub() });
            target.RegisterNewGeneration(population);
            Assert.AreEqual(4, population.Generations.Count);
        }

        [Test]
        public void RegisterNewGeneration_GenerationExceedGenerationsNumber_RemoveOldOne()
        {
            var target = new PerformanceGenerationStrategy();
            var population = new Population(2, 6, new ChromosomeStub());

            population.CreateInitialGeneration();
            target.RegisterNewGeneration(population);
            Assert.AreEqual(1, population.Generations.Count);

            population.CreateNewGeneration(new List<IChromosome>() { new ChromosomeStub(), new ChromosomeStub() });
            target.RegisterNewGeneration(population);
            Assert.AreEqual(1, population.Generations.Count);

            population.CreateNewGeneration(new List<IChromosome>() { new ChromosomeStub(), new ChromosomeStub() });
            target.RegisterNewGeneration(population);
            Assert.AreEqual(1, population.Generations.Count);

            population.CreateNewGeneration(new List<IChromosome>() { new ChromosomeStub(), new ChromosomeStub() });
            target.RegisterNewGeneration(population);
            Assert.AreEqual(1, population.Generations.Count);
        }
    }
}