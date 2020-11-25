using Newtonsoft.Json;
using SWDemo.Models.Response;
using SWDemo.Settings;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SWDemo.Utilities
{
    public class RestClient
    {
        private Uri Uri = new Uri(ApiSettings.API_URL);
        public async Task<T> Get<T>(string method)
        {
            try
            {
                HttpClient client;
                if (GlobalConfig.Identity != null)
                    client = HTTPClientFormated.GetBearerClient();
                else
                    client = new HttpClient();
                client.BaseAddress = Uri;
                var response = await client.GetAsync(method);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Content.ReadAsStringAsync().Result.Replace("\n", "");
                    var final = JsonConvert.DeserializeObject<T>(result);
                    (final as ResponseBaseModel).Success = true;
                    return final;
                }
                else
                    return ErrorConvention<T>(response);
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.ToString());
            }
            return default(T);
        }

        public async Task<T> Post<T>(string method, object o)
        {
            try
            {
                HttpClient client;
                if (GlobalConfig.Identity != null)
                    client = HTTPClientFormated.GetBearerClient();
                else
                    client = new HttpClient();
                var post = JsonConvert.SerializeObject(o);
                HttpContent contenidoPOST = new StringContent(post, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Uri + method, contenidoPOST);
                if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var result = (await response.Content.ReadAsStringAsync()).Replace("\n", "");
                    var final = JsonConvert.DeserializeObject<T>(result);
                    (final as ResponseBaseModel).Success = true;
                    return final;
                }
                else
                    return ErrorConvention<T>(response);
            }
            catch (Exception exc)
            {
                string error = exc.ToString();
            }
            return default(T);
        }

        public async Task<T> Put<T>(string method, object o)
        {
            try
            {
                HttpClient client;
                if (GlobalConfig.Identity != null)
                    client = HTTPClientFormated.GetBearerClient();
                else
                    client = new HttpClient();
                var post = JsonConvert.SerializeObject(o);
                HttpContent contenidoPUT = new StringContent(post, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(Uri + method, contenidoPUT);
                if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var result = response.Content.ReadAsStringAsync().Result.Replace("\n", "");
                    var final = JsonConvert.DeserializeObject<T>(result);
                    (final as ResponseBaseModel).Success = true;
                    return final;
                }
                else
                    return ErrorConvention<T>(response);
            }
            catch (Exception exc)
            {
                string error = exc.ToString();
            }
            return default(T);
        }

        public async Task<T> Patch<T>(string method, object o)
        {
            try
            {
                HttpClient client;
                if (GlobalConfig.Identity != null)
                    client = HTTPClientFormated.GetBearerClient();
                else
                    client = new HttpClient();

                HttpRequestMessage RequestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), Uri + method);
                var patchContent = JsonConvert.SerializeObject(o);
                RequestMessage.Content = new StringContent(patchContent, Encoding.UTF8, "application/json");

                var response = await client.SendAsync(RequestMessage);
                if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var result = response.Content.ReadAsStringAsync().Result.Replace("\n", "");
                    var final = JsonConvert.DeserializeObject<T>(result);
                    (final as ResponseBaseModel).Success = true;
                    return final;
                }
                else
                    return ErrorConvention<T>(response);
            }
            catch (Exception exc)
            {
                string error = exc.ToString();
            }
            return default(T);
        }

        public async Task<T> Delete<T>(string method)
        {
            try
            {
                HttpClient client;
                if (GlobalConfig.Identity != null)
                    client = HTTPClientFormated.GetBearerClient();
                else
                    client = new HttpClient();
                client.BaseAddress = Uri;
                var response = await client.DeleteAsync(method);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Content.ReadAsStringAsync().Result.Replace("\n", "");
                    var final = JsonConvert.DeserializeObject<T>(result);
                    (final as ResponseBaseModel).Success = true;
                    return final;
                }
                else
                    return ErrorConvention<T>(response);
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.ToString());
            }
            return default(T);
        }

        protected T ErrorConvention<T>(HttpResponseMessage response)
        {
            try
            {
                var errorResult = response.Content.ReadAsStringAsync().Result.Replace("\n", "");
                var result = JsonConvert.DeserializeObject<T>(errorResult);
                (result as ResponseBaseModel).Success = false;
                return result;
            }
            catch (Exception exc)//Super unhandled error, probably means data inconsinstency (like a null int or similar)
            {
                var tResult = JsonConvert.DeserializeObject<T>("{ }");
                return tResult;
            }
        }

    }
}
