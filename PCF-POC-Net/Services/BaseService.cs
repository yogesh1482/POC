using PCF_POC.Interfaces;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PCF_POC.Services
{
    public class BaseService : IBaseService
    {
        private string baseUrl;
        private AppSettings _settings { get; set; }

        //public BaseService(IOptions<AppSettings> settings)
        //{
        //    _settings = settings.Value;
        //    baseUrl = _settings.WebApiUri;
        //}

        public BaseService()
        {
            //_settings = settings.Value;
            //baseUrl = "http://localhost:1438/";
            baseUrl = ConfigurationManager.AppSettings["WebApiUri"];
        }

        private HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public async Task<String> ExecuteRequestAsync(string query)
        {
            HttpClient client = GetHttpClient();
            HttpResponseMessage response = null;
            try
            {
                response = client.GetAsync((baseUrl + query), HttpCompletionOption.ResponseContentRead).Result;
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            finally
            {
                if (client != null)
                    client.Dispose();
                if (response != null)
                    response.Dispose();
            }
        }
    }
}
