using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolNameGenerator.GA;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Populations;
using CoolNameGenerator.GA.Randomizations;
using CoolNameGenerator.GeneticWordProcessing;
using CoolNameGenerator.Helper;

namespace CoolNameGenerator.Forms
{
    public partial class CoolNameResultForm : BaseForm
    {
        public CoolNameResultForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            wpResults.SetWordsCount((int) numPopulationSize.Value);


            Run();
        }

        private void Controller_BestWordFound(string bestResult)
        {
            wpResults.WordsLabels[0].Text = bestResult;
        }

        private void finglishConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FinglishConverter().ShowDialog();
        }


        private async void Run()
        {
            await Task.Run(() =>
            {
                var controller = new WordGaController();
                controller.BestWordFound += Controller_BestWordFound;
                var selection = controller.CreateSelection();
                var crossover = controller.CreateCrossover();
                var mutation = controller.CreateMutation();
                var fitness = controller.CreateFitness();
                var population = new Population(100, 200, controller.CreateChromosome());
                population.GenerationStrategy = new PerformanceGenerationStrategy();

                var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
                ga.Termination = controller.CreateTermination();

                ga.GenerationRan += delegate
                {
                    var bestChromosome = ga.Population.BestChromosome;
                    //Console.WriteLine("Generations: {0}", ga.Population.GenerationsNumber);
                    //Console.WriteLine("Fitness: {0,10}", bestChromosome.Fitness);
                    //Console.WriteLine("Time: {0}", ga.TimeEvolving);
                    controller.Draw(bestChromosome);
                };

                try
                {
                    controller.ConfigGa(ga);
                    ga.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            });
        }
    }
}
