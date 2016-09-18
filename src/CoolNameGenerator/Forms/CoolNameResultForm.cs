using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolNameGenerator.GA;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Populations;
using CoolNameGenerator.GA.Randomizations;
using CoolNameGenerator.GeneticWordProcessing;
using CoolNameGenerator.Helper;
using CoolNameGenerator.Properties;

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

        private void finglishConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FinglishConverter().ShowDialog();
        }


        private async void Run()
        {
            await Task.Run(async () =>
            {
                try
                {
                    var ctrl = new WordGaController(() => new WordChromosome((int)numWordLen.Value, chkHasNumeric.Checked, chkHasHyphen.Checked), DrawChromosomes);
                    await ctrl.LoadWordFiles();

                    var population = new Population((int)numPopulationSize.Value, 2000, ctrl.CreateChromosome(), new PerformanceGenerationStrategy(10));

                    var ga = new GeneticAlgorithm(population, ctrl.CreateFitness(), ctrl.CreateSelection(),
                        ctrl.CreateCrossover(population), ctrl.CreateMutation(), ctrl.CreateTermination());

                    ga.GenerationRan += delegate
                    {
                        var bestChromosome = ga.Population.BestChromosome;
                        lblFitness.InvokeIfRequired(() => lblFitness.Text = bestChromosome.Fitness.ToString());
                        lblBestChromosome.InvokeIfRequired(() => lblBestChromosome.Text = bestChromosome.ToString());
                        lblGeneration.InvokeIfRequired(() => lblGeneration.Text = ga.Population.GenerationsNumber.ToString());
                        lblTimeEvolving.InvokeIfRequired(() => lblTimeEvolving.Text = ga.TimeEvolving.ToString());
                        ctrl.Draw(bestChromosome);
                        ctrl.DrawAllAction(ga.Population.CurrentGeneration.Chromosomes);
                    };

                    ga.TerminationReached += GaTerminationReached;

                    ctrl.ConfigGa(ga);
                    ga.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            });
        }

        private void GaTerminationReached(object sender, EventArgs e)
        {
            MessageBox.Show(Localization.AlgorithmTerminatedSuccessful);
        }

        private void DrawChromosomes(IList<IChromosome> chromosomes)
        {
            if (chkDisplayRealtime.Checked)
            {
                wpResults.SetWords(chromosomes);
            }
        }
    }
}
