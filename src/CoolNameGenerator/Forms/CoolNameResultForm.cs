using System;
using System.Linq;
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
            wpResults.SetWordsCount((int)numPopulationSize.Value);

            Run();
        }

        //private void Controller_BestWordFound(string bestResult)
        //{
        //    wpResults.WordsLabels[0].Text = bestResult;
        //}

        private void finglishConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FinglishConverter().ShowDialog();
        }


        private async void Run()
        {
            await Task.Run(() =>
            {
                var controller = new WordGaController(() => new WordChromosome((int)numWordMinLen.Value, (int)numWordMaxLen.Value, chkHasNumeric.Checked, chkHasHyphen.Checked));
                //controller.BestWordFound += Controller_BestWordFound;
                var selection = controller.CreateSelection();
                var crossover = controller.CreateCrossover();
                var mutation = controller.CreateMutation();
                var fitness = controller.CreateFitness();
                var population = new Population((int)numPopulationSize.Value, 2000, controller.CreateChromosome());
                population.GenerationStrategy = new PerformanceGenerationStrategy();

                var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
                ga.Termination = controller.CreateTermination();

                ga.GenerationRan += delegate
                {
                    var bestChromosome = ga.Population.BestChromosome;
                    lblFitness.InvokeIfRequired(() => lblFitness.Text = bestChromosome.Fitness.ToString());
                    lblBestChromosome.InvokeIfRequired(() => lblBestChromosome.Text = bestChromosome.ToString());
                    lblGeneration.InvokeIfRequired(() => lblGeneration.Text = ga.Population.GenerationsNumber.ToString());
                    lblTimeEvolving.InvokeIfRequired(() => lblTimeEvolving.Text = ga.TimeEvolving.ToString());
                    controller.Draw(bestChromosome);
                    wpResults.SetWords(ga.Population.CurrentGeneration.Chromosomes);
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
