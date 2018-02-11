using NetSolutionWorkSample.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetSolutionWorkSample.Services
{
    public class HttpBaseService
    {
        protected async Task<string> GetHttpClientAsync(string baseUri, string requestUri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                var response = await client.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
