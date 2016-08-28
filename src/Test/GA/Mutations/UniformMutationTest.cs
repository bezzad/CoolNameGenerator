using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Mutations;
using NUnit.Framework;
using Rhino.Mocks;
using TestSharp;

namespace Test.GA.Mutations
{
    [TestFixture()]
    [Category("Mutations")]
    public class UniformMutationTest
    {
        [Test()]
        public void Mutate_NoIndexes_RandomOneIndex()
        {
            var target = new UniformMutation();
            var chromosome = MockRepository.GenerateStub<ChromosomeBase>(3);
            chromosome.ReplaceGenes(0, new Gene[]
            {
                new Gene(1),
                new Gene(1),
                new Gene(1)
            });

            chromosome.Expect(c => c.GenerateGene(1)).Return(new Gene(0));

            target.Mutate(chromosome, 1);
            Assert.AreEqual(1, chromosome.GetGene(0).Value);
            Assert.AreEqual(0, chromosome.GetGene(1).Value);
            Assert.AreEqual(1, chromosome.GetGene(2).Value);

            chromosome.VerifyAllExpectations();
        }

        [Test()]
        public void Mutate_InvalidIndexes_Exception()
        {
            var target = new UniformMutation(0, 3);
            var chromosome = MockRepository.GenerateStub<ChromosomeBase>(3);
            chromosome.ReplaceGenes(0, new Gene[]
                                                     {
                new Gene(1),
                new Gene(1),
                new Gene(1)
            });

            chromosome.Expect(c => c.GenerateGene(0)).Return(new Gene(0));
           
            ExceptionAssert.IsThrowing(new MutationException(target, "The chromosome has no gene on index 3. The chromosome genes length is 3."), () =>
            {
                target.Mutate(chromosome, 1);
            });

            chromosome.VerifyAllExpectations();
        }

        [Test()]
        public void Mutate_Indexes_RandomIndexes()
        {
            var target = new UniformMutation(0, 2);
            var chromosome = MockRepository.GenerateStub<ChromosomeBase>(3);
            chromosome.ReplaceGenes(0, new Gene[]
                                                     {
                new Gene(1),
                new Gene(1),
                new Gene(1)
            });

            chromosome.Expect(c => c.GenerateGene(0)).Return(new Gene(0));
            chromosome.Expect(c => c.GenerateGene(2)).Return(new Gene(10));

            target.Mutate(chromosome, 1);
            Assert.AreEqual(0, chromosome.GetGene(0).Value);
            Assert.AreEqual(1, chromosome.GetGene(1).Value);
            Assert.AreEqual(10, chromosome.GetGene(2).Value);

            chromosome.VerifyAllExpectations();
        }

        [Test()]
        public void Mutate_AllGenesMutablesTrue_AllGenesMutaed()
        {
            var target = new UniformMutation(true);
            var chromosome = MockRepository.GenerateStub<ChromosomeBase>(3);
            chromosome.ReplaceGenes(0, new Gene[]
                                 {
                new Gene(1),
                new Gene(1),
                new Gene(1)
            });

            chromosome.Expect(c => c.GenerateGene(0)).Return(new Gene(0));
            chromosome.Expect(c => c.GenerateGene(1)).Return(new Gene(10));
            chromosome.Expect(c => c.GenerateGene(2)).Return(new Gene(20));

            target.Mutate(chromosome, 1);
            Assert.AreEqual(0, chromosome.GetGene(0).Value);
            Assert.AreEqual(10, chromosome.GetGene(1).Value);
            Assert.AreEqual(20, chromosome.GetGene(2).Value);

            chromosome.VerifyAllExpectations();
        }
    }
}