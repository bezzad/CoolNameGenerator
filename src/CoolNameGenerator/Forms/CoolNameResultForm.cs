using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolNameGenerator.GA;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Populations;
using CoolNameGenerator.GeneticWordProcessing;
using CoolNameGenerator.Graphics;
using CoolNameGenerator.Helper;
using CoolNameGenerator.Properties;

namespace CoolNameGenerator.Forms
{
    public partial class CoolNameResultForm : BaseForm
    {
        private readonly Dictionary<string, double?> _bestChromosomes = new Dictionary<string, double?>();
        private GeneticAlgorithm _ga;

        public CoolNameResultForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == Localization.Start)
            {
                btnStart.Text = Localization.Stop;

                wpResults.SetWordsCount((int) numPopulationSize.Value);
                SetOnDoubleClickForWordsToAddInGrid(wpResults);

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
            await Task.Run(() =>
            {
                try
                {
                    var pop = (int) numPopulationSize.Value;
                    var ctrl =
                        new WordGaController(
                            () =>
                                new WordChromosome((int) numWordLen.Value, chkHasNumeric.Checked, chkHasHyphen.Checked));
                    ctrl.LoadWordFiles(GetWordsDictionaries().ToList(), null);
                    ctrl.CrossoverProbability = (float) numCrossoverProbability.Value/100;
                    ctrl.MutationProbability = (float) numMutationProbability.Value/100;
                    ctrl.EliteSelectionNumber = (int) numEliteSelection.Value*pop/100;
                    ctrl.GenerationsNumber = (int) numGenerationKeepingNumber.Value;
                    ctrl.MinimumThread = (int) numMinimumThread.Value;
                    ctrl.MaximumThread = (int) numMaximumThread.Value;
                    ctrl.FitnessThresholdTermination = (double) numFitnessThresholdTermination.Value;
                    ctrl.TimeEvolvingTermination = TimeSpan.FromMinutes((int) numTimeEvolvingTermination.Value);

                    var population = new Population(pop, pop + 1000, ctrl.CreateChromosome(),
                        new PerformanceGenerationStrategy(ctrl.GenerationsNumber));

                    _ga = new GeneticAlgorithm(population, ctrl.CreateFitness(), ctrl.CreateSelection(),
                        ctrl.CreateCrossover(), ctrl.CreateMutation(), ctrl.CreateTermination());

                    _ga.GenerationRan += delegate
                    {
                        var bestChromosome = _ga.Population.BestChromosome;
                        lblFitness.InvokeIfRequired(() => lblFitness.Text = bestChromosome.Fitness.ToString());
                        bestChromosomeWord.InvokeIfRequired(
                            () => bestChromosomeWord.SetChromosome((WordChromosome) bestChromosome));
                        AddBestChromosomes(bestChromosome);
                        lblGeneration.InvokeIfRequired(
                            () => lblGeneration.Text = _ga.Population.GenerationsNumber.ToString());
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

            var ch = (WordChromosome) bestChromosome;

            AddBestChromosomes(ch.ToString(), ch.Fitness);
        }

        private void AddBestChromosomes(string word, double? fitness)
        {
            if (_bestChromosomes.ContainsKey(word)) return;

            _bestChromosomes[word] = fitness;

            dgvBestResults.InvokeIfRequired(() => dgvBestResults.Rows.Add(word, fitness));
            dgvBestResults.InvokeIfRequired(
                () => dgvBestResults.Sort(dgvBestResults.Columns["colFitness"], ListSortDirection.Descending));
        }

        private void btnAddWordDictionaries_Click(object sender, EventArgs e)
        {
            AddWordsDic(new WordsDictionary());
        }

        private void AddWordsDic(WordsDictionary wordDic)
        {
            panelExtraWordsDic.Controls.Add(wordDic);
        }

        protected override async void LoadCompleted(object sender, EventArgs e)
        {
            base.LoadCompleted(sender, e);

            var englishWordsDic = new WordsDictionary();
            await englishWordsDic.LoadData(FileExtensions.GetResourcePath("EnglishWords", "txt"));
            englishWordsDic.DuplicateMatchingFitness = -4;
            englishWordsDic.MatchingFitness = 6;
            englishWordsDic.NoMatchingFitness = -1;
            AddWordsDic(englishWordsDic);

            var englishNamesDic = new WordsDictionary();
            await englishNamesDic.LoadData(FileExtensions.GetResourcePath("EnglishNames", "txt"));
            englishNamesDic.DuplicateMatchingFitness = -20;
            englishNamesDic.MatchingFitness = 4;
            englishNamesDic.NoMatchingFitness = 0;
            AddWordsDic(englishNamesDic);

            var finglishNamesDic = new WordsDictionary();
            await finglishNamesDic.LoadData(FileExtensions.GetResourcePath("FinglishNames", "txt"));
            finglishNamesDic.DuplicateMatchingFitness = -4;
            finglishNamesDic.MatchingFitness = 10;
            finglishNamesDic.NoMatchingFitness = -2;
            AddWordsDic(finglishNamesDic);


            var finglishWordsDic = new WordsDictionary();
            await finglishWordsDic.LoadData(FileExtensions.GetResourcePath("FinglishWords", "txt"));
            finglishWordsDic.DuplicateMatchingFitness = -10;
            finglishWordsDic.MatchingFitness = 4;
            finglishWordsDic.NoMatchingFitness = 0;
            AddWordsDic(finglishWordsDic);
        }

        private IEnumerable<UniqueWords> GetWordsDictionaries()
        {
            return from object ctrl in panelExtraWordsDic.Controls
                where ctrl.GetType() == typeof(WordsDictionary) && ((WordsDictionary) ctrl).Enabled
                select ((WordsDictionary) ctrl).Words;
        }

        private void SetOnDoubleClickForWordsToAddInGrid(WordsPanel wp)
        {
            foreach (var lblWord in wp.WordsLabels)
            {
                lblWord.DoubleClick += (s, e) =>
                {
                    var word = s as WordLabel;
                    AddBestChromosomes(word?.Text, word?.Fitness);
                };
            }
        }
    }
}