using SWDemo.Settings;
using System;
using System.Net.Http;

namespace SWDemo.Utilities
{
    public class HTTPClientFormated
    {
        //TODO: Authenticated API, review if it have a google key or similar
        public static HttpClient GetBearerClient()
        {
            var cliente = GetDefaultHttpClient();
            cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GlobalConfig.Token);
            return cliente;
        }
        public static HttpClient GetDefaultHttpClient()
        {
            var cliente = new HttpClient();
            cliente.Timeout = TimeSpan.FromMinutes(60);
            return cliente;
        }
    }
}
