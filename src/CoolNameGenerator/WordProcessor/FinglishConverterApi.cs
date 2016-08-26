using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolNameGenerator.Properties;

namespace CoolNameGenerator.WordProcessor
{
    public class FinglishConverterApi
    {
        protected const string FinglishWebApiBaseAddress = "http://f2f-onezeroir.rhcloud.com";
        protected const string FinglishWebApiQueryKey = "word";

        public delegate void ProgressChangedEventHandler(string persian, string finglish, int row, int count);
        public event ProgressChangedEventHandler ProgressChanged = delegate { };
        protected virtual void OnProgressChanged(string persian, string finglish, int row, int count)
        {
            ProgressChanged?.Invoke(persian, finglish, row, count);
        }

        public EventHandler ProgressStarted = delegate { };
        public EventHandler ProgressCompleted = delegate { };


        public async Task<string> GetFinglish(string persian)
        {
            var res = await GetAsync(FinglishWebApiBaseAddress, queryParams: new Dictionary<string, string> { { FinglishWebApiQueryKey, persian } });

            return res ?? "";
        }

        public async Task<List<Tuple<string, string>>> GetFinglishAsync(string[] persians)
        {
            var words = new List<Tuple<string, string>>();

            try
            {
                ProgressStarted(this, new EventArgs());

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(FinglishWebApiBaseAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    for (var row = 0; row < persians.Length; row++)
                    {
                        var query = $"/?{FinglishWebApiQueryKey}={persians[row]}";
                        HttpResponseMessage response = await client.GetAsync(query);
                        if (response.IsSuccessStatusCode)
                        {
                            var rawResponse = await response.Content.ReadAsByteArrayAsync();
                            var result = Encoding.UTF8.GetString(rawResponse, 0, rawResponse.Length);
                            if (result[0] == '\uFEFF')
                            {
                                result = result.Substring(1);
                            }
                            words.Add(Tuple.Create(persians[row], result));
                            OnProgressChanged(persians[row], result, row, persians.Length);
                        }
                        else
                        {
                            OnProgressChanged(persians[row], null, row, persians.Length);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, Localization.GetFinglish_Exception);
            }
            finally
            {
                ProgressCompleted(this, new EventArgs());
            }

            return words;
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
