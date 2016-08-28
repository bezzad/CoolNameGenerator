using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Mutations;
using CoolNameGenerator.Helper;
using NUnit.Framework;
using Rhino.Mocks;
using TestSharp;

namespace Test.GA.Mutations
{
    [TestFixture()]
    [Category("Mutations")]
    public class ReverseSequenceMutationTest
    {
        [Test()]
        public void Mutate_LessThanThreeGenes_Exception()
        {
            var target = new ReverseSequenceMutation();
            var chromosome = MockRepository.GenerateStub<ChromosomeBase>(2);
            chromosome.ReplaceGenes(0, new Gene[]
                                    {
                new Gene(1),
            });

            ExceptionAssert.IsThrowing(new MutationException(target, "A chromosome should have, at least, 3 genes. {0} has only 2 gene.".With(chromosome.GetType().Name)), () =>
            {
                target.Mutate(chromosome, 0);
            });
        }

        [Test()]
        public void Mutate_NoProbality_NoReverseSequence()
        {
            var target = new ReverseSequenceMutation();
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
        public void Mutate_ValidChromosome_ReverseSequence()
        {
            var target = new ReverseSequenceMutation();
            var chromosome = MockRepository.GenerateStub<ChromosomeBase>(6);
            chromosome.ReplaceGenes(0, new Gene[]
                                    {
                new Gene(1),
                new Gene(2),
                new Gene(3),
                new Gene(4),
                new Gene(5),
                new Gene(6),
            });
            
            target.Mutate(chromosome, 1);

            Assert.AreEqual(6, chromosome.Length);
            Assert.AreEqual(1, chromosome.GetGene(0).Value);
            Assert.AreEqual(5, chromosome.GetGene(1).Value);
            Assert.AreEqual(4, chromosome.GetGene(2).Value);
            Assert.AreEqual(3, chromosome.GetGene(3).Value);
            Assert.AreEqual(2, chromosome.GetGene(4).Value);
            Assert.AreEqual(6, chromosome.GetGene(5).Value);
            
            chromosome.VerifyAllExpectations();
        }
    }
}

