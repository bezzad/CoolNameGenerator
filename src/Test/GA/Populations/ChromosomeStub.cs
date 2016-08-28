using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Randomizations;

namespace Test.GA.Populations
{
    public class ChromosomeStub : ChromosomeBase
    {
        public ChromosomeStub(double fitness)
            : base(2)
        {
            Fitness = fitness;
        }

        public ChromosomeStub() : base(4)
        {
            ReplaceGene(0, GenerateGene(0));
            ReplaceGene(1, GenerateGene(1));
            ReplaceGene(2, GenerateGene(2));
            ReplaceGene(3, GenerateGene(3));
        }

        public override Gene GenerateGene(int geneIndex)
        {
            return new Gene(FastRandom.Next(0, 6));
        }

        public override IChromosome CreateNew()
        {
            return new ChromosomeStub();
        }
    }
}
