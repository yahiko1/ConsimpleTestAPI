using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace ConsimpleTestAPI.ConsimpleAPIClient
{
    public class RestClient : HttpClient
    {
        private string _baseUri = "https://tester.consimple.pro/";
        
        public RestClient()
        {
            InitializeTlsProtocol();
        }

        public async Task<Response> GetAsync(string url, Dictionary<string, string> query)
        {
            DefaultRequestHeaders.Clear();
            DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue() { NoCache = true };
            
            using (var response = await GetAsync(Utils.AddQueryString(_baseUri + url, query)))
            {
                if (!response.IsSuccessStatusCode) 
                    throw new Exception(response.ReasonPhrase);
                
                var stringResponse = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Response>(stringResponse);

            }
        }

        public async Task<string> PostAsync(string url, string data)
        {
            DefaultRequestHeaders.Clear();
            DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue() { NoCache = true };

            var content = new StringContent(data, Encoding.UTF8, "application/json");

            using (var response = await PostAsync(_baseUri + url, content))
            {
                if (!response.IsSuccessStatusCode) 
                    throw new Exception(response.ReasonPhrase);
                
                return await response.Content.ReadAsStringAsync();
            }
        }

        private void InitializeTlsProtocol()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }
    }
}