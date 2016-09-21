﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolNameGenerator.GA;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Populations;
using CoolNameGenerator.GeneticWordProcessing;
using CoolNameGenerator.Helper;
using CoolNameGenerator.Properties;
using System.Linq;

namespace CoolNameGenerator.Forms
{
    public partial class CoolNameResultForm : BaseForm
    {
        private GeneticAlgorithm _ga;
        private readonly Dictionary<string, WordChromosome> _bestChromosomes = new Dictionary<string, WordChromosome>();

        public CoolNameResultForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == Localization.Start)
            {
                btnStart.Text = Localization.Stop;

                wpResults.SetWordsCount((int)numPopulationSize.Value);

                Run();
            }
            else
            {
                btnStart.Text = Localization.Start;
                _ga?.Stop();
            }

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
                    var pop = (int)numPopulationSize.Value;
                    var ctrl = new WordGaController(() => new WordChromosome((int)numWordLen.Value, chkHasNumeric.Checked, chkHasHyphen.Checked));
                    await ctrl.LoadWordFiles();
                    ctrl.CrossoverProbability = (float)numCrossoverProbability.Value / 100;
                    ctrl.MutationProbability = (float)numMutationProbability.Value / 100;
                    ctrl.EliteSelectionNumber = (int)numEliteSelection.Value * pop / 100;
                    ctrl.GenerationsNumber = (int)numGenerationKeepingNumber.Value;

                    var population = new Population(pop, pop + 1000, ctrl.CreateChromosome(), new PerformanceGenerationStrategy(ctrl.GenerationsNumber));

                    _ga = new GeneticAlgorithm(population, ctrl.CreateFitness(), ctrl.CreateSelection(),
                        ctrl.CreateCrossover(), ctrl.CreateMutation(), ctrl.CreateTermination());

                    _ga.GenerationRan += delegate
                    {
                        var bestChromosome = _ga.Population.BestChromosome;
                        lblFitness.InvokeIfRequired(() => lblFitness.Text = bestChromosome.Fitness.ToString());
                        bestChromosomeWord.InvokeIfRequired(() => bestChromosomeWord.SetChromosome((WordChromosome)bestChromosome));
                        AddBestChromosomes(bestChromosome);
                        lblGeneration.InvokeIfRequired(() => lblGeneration.Text = _ga.Population.GenerationsNumber.ToString());
                        lblTimeEvolving.InvokeIfRequired(() => lblTimeEvolving.Text = _ga.TimeEvolving.ToString());
                        ctrl.Draw(bestChromosome);
                        DrawChromosomes(_ga.Population.CurrentGeneration.Chromosomes);
                    };

                    _ga.TerminationReached += GaTerminationReached;

                    ctrl.ConfigGa(_ga);
                    _ga.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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

        private void AddBestChromosomes(IChromosome bestChromosome)
        {
            if (bestChromosome.GetType() != typeof(WordChromosome)) return;

            _bestChromosomes[bestChromosome.ToString()] = (WordChromosome)bestChromosome;
            //bestWordPanels.SetWords(_bestChromosomes.Values.ToList() as IList<IChromosome>);
        }
    }
}