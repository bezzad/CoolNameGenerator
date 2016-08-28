using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Mutations;
using NUnit.Framework;
using Rhino.Mocks;

namespace Test.GA.Mutations
{
    [TestFixture]
    [Category("Mutations")]
    public class TworsMutationTest
    {
        [Test()]
        public void Mutate_NoProbality_NoExchangeGenes()
        {
            var target = new TworsMutation();
            var chromosome = MockRepository.GenerateStub<ChromosomeBase>(4);
            chromosome.ReplaceGenes(0, new Gene[]
            {
                new Gene(1),
                new Gene(2),
                new Gene(3),
                new Gene(4),
            });

            target.Mutate(chromosome, 0);

            Assert.AreEqual(4, chromosome.Length);
            Assert.AreEqual(1, chromosome.GetGene(0).Value);
            Assert.AreEqual(2, chromosome.GetGene(1).Value);
            Assert.AreEqual(3, chromosome.GetGene(2).Value);
            Assert.AreEqual(4, chromosome.GetGene(3).Value);

            chromosome.VerifyAllExpectations();
        }

        [Test()]
        public void Mutate_ValidChromosome_ExchangeGenes()
        {
            var target = new TworsMutation();
            var chromosome = MockRepository.GenerateStub<ChromosomeBase>(4);
            chromosome.ReplaceGenes(0, new Gene[]
                                                     {
                new Gene(1),
                new Gene(2),
                new Gene(3),
                new Gene(4),
            });
            
            target.Mutate(chromosome, 1);

            Assert.AreEqual(4, chromosome.Length);
            Assert.AreEqual(3, chromosome.GetGene(0).Value);
            Assert.AreEqual(2, chromosome.GetGene(1).Value);
            Assert.AreEqual(1, chromosome.GetGene(2).Value);
            Assert.AreEqual(4, chromosome.GetGene(3).Value);
            
            chromosome.VerifyAllExpectations();
        }
    }
}