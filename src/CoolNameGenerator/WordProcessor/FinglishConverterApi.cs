using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CoolNameGenerator.WordProcessor
{
    public class FinglishConverterApi
    {
        protected const string FinglishWebApiBaseAddress = "http://f2f-onezeroir.rhcloud.com";
        protected const string FinglishWebApiQueryKey = "word";


        public async Task<string> GetFinglish(string persian)
        {
            var res = await GetAsync(FinglishWebApiBaseAddress, queryParams: new Dictionary<string, string> { { FinglishWebApiQueryKey, persian } });

            return res ?? "";
        }

        public async Task<List<Tuple<string, string>>> GetFinglish(string[] persians)
        {
            var result = new List<Tuple<string, string>>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(FinglishWebApiBaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                foreach (var word in persians)
                {
                    var query = $"/?{FinglishWebApiQueryKey}={word}";
                    HttpResponseMessage response = await client.GetAsync(query);
                    if (response.IsSuccessStatusCode)
                    {
                        result.Add(Tuple.Create(word, await response.Content.ReadAsStringAsync()));
                    }
                }
            }

            return result;
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
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return null;
        }
    }
}
