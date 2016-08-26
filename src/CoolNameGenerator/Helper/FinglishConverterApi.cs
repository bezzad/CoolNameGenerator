using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolNameGenerator.Properties;

namespace CoolNameGenerator.Helper
{
    public class FinglishConverterApi
    {
        protected const string FinglishWebApiBaseAddress = "http://f2f-onezeroir.rhcloud.com";
        protected const string FinglishWebApiQueryKey = "word";
        public int MaxParallelismDegree = Environment.ProcessorCount;

        public delegate void ProgressChangedEventHandler(string persian, string finglish);
        public event ProgressChangedEventHandler ProgressChanged = delegate { };
        protected virtual void OnProgressChanged(string persian, string finglish)
        {
            ProgressChanged?.Invoke(persian, finglish);
        }

        public EventHandler ProgressStarted = delegate { };
        public EventHandler ProgressCompleted = delegate { };


        protected virtual async Task<List<Tuple<string, string>>> GetFinglishByOneHttpClientAsync(string[] persians, CancellationTokenSource cts)
        {
            var words = new List<Tuple<string, string>>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(FinglishWebApiBaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                foreach (var w in persians)
                {
                    if (cts != null && cts.IsCancellationRequested) break;

                    var query = $"/?{FinglishWebApiQueryKey}={w}";
                    var response = await client.GetAsync(query); // return HttpResponseMessage
                    if (response.IsSuccessStatusCode)
                    {
                        var rawResponse = await response.Content.ReadAsByteArrayAsync();
                        var result = Encoding.UTF8.GetString(rawResponse, 0, rawResponse.Length);
                        if (result[0] == '\uFEFF')
                        {
                            result = result.Substring(1);
                        }
                        words.Add(Tuple.Create(w, result));
                        OnProgressChanged(w, result);
                    }
                    else
                    {
                        OnProgressChanged(w, null);
                    }
                }
            }

            return words;
        }

        public async Task<List<Tuple<string, string>>> GetFinglishAsync(string[] persians, CancellationTokenSource cts)
        {
            try
            {
                ProgressStarted(this, new EventArgs());

                return await GetFinglishByOneHttpClientAsync(persians, cts);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, Localization.GetFinglish_Exception);
            }
            finally
            {
                ProgressCompleted(this, new EventArgs());
            }

            return new List<Tuple<string, string>>();
        }

        public async Task<List<Tuple<string, string>>> GetParallelFinglishAsync(string[] persians, CancellationTokenSource cts)
        {
            var result = new List<List<Tuple<string, string>>>();

            try
            {
                ProgressStarted(this, new EventArgs());

                var chunkedArray = persians.ChunkArray(MaxParallelismDegree);
                var tasks = new Task[MaxParallelismDegree];

                for (int tCount = 0; tCount < MaxParallelismDegree; tCount++)
                {
                    if (cts.IsCancellationRequested) return result.SelectMany(x => x).ToList();

                    tasks[tCount] = Task.Run(async () => result.Add(await GetFinglishByOneHttpClientAsync(chunkedArray[tCount], cts)), cts.Token);
                    await Task.Delay(50);
                }

                await Task.Run(() => Task.WaitAll(tasks.ToArray()));
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, Localization.GetFinglish_Exception);
            }
            finally
            {
                ProgressCompleted(this, new EventArgs());
            }

            return result.SelectMany(x => x).ToList();
        }



        public async Task<string> GetFinglish(string persian)
        {
            var res = await GetAsync(FinglishWebApiBaseAddress, queryParams: new Dictionary<string, string> { { FinglishWebApiQueryKey, persian } });

            return res ?? "";
        }
        protected static async Task<string> GetAsync(string baseAddress, Dictionary<string, string> queryParams)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var query = queryParams.Aggregate("/?", (current, q) => current + $"{q.Key}={q.Value}&");
                query = query.Remove(query.Length - 1);

                HttpResponseMessage response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var rawResponse = await response.Content.ReadAsByteArrayAsync();
                    var result = Encoding.UTF8.GetString(rawResponse, 0, rawResponse.Length);
                    if (result[0] == '\uFEFF')
                    {
                        result = result.Substring(1);
                    }
                    return result;
                }
            }

            return null;
        }
    }
}