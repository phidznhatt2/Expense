using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Plugin.RestClient
{
    public class RestClient<T> {
        private const string WebServiceUrl = "https://samonvp.somee.com/api";

        public async Task<T> GetAsync(string url) {

            var newUrl = WebServiceUrl + "/" + url;

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(newUrl);

            var taskModels = JsonConvert.DeserializeObject<T>(json);

            return taskModels;
        }

        public async Task<T> GetRegisterAsyncById(string url)
        {

            var newUrl = WebServiceUrl + "/" + url;

            var httpClient = new HttpClient();

            var oauthToken = "";

            try
            {
                oauthToken = await SecureStorage.GetAsync("oauthtoken");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception ", ex);
            }

            var accessToken = new AuthenticationHeaderValue("Bearer", oauthToken);
   
            httpClient.DefaultRequestHeaders.Authorization = accessToken;

            var json = await httpClient.GetStringAsync(newUrl);

            var taskModels = JsonConvert.DeserializeObject<T>(json);

            return taskModels;
        }

        public async Task<T> GetAsyncById(int id, string url) {

            var newUrl = WebServiceUrl + "/" + url + "/" + id;

            var httpClient = new HttpClient();

            var oauthToken = "";

            try
            {
                oauthToken = await SecureStorage.GetAsync("oauthtoken");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception ", ex);
            }

            var accessToken = new AuthenticationHeaderValue("Bearer", oauthToken);

            httpClient.DefaultRequestHeaders.Authorization = accessToken;

            var json = await httpClient.GetStringAsync(newUrl);

            var taskModels = JsonConvert.DeserializeObject<T>(json);

            return taskModels;
        }

        public async Task<bool> PostAsync(T t, string url) {

            var newUrl = WebServiceUrl + "/" + url;

            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var oauthToken = "";

            try
            {
                oauthToken = await SecureStorage.GetAsync("oauthtoken");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception ", ex);
            }

            var accessToken = new AuthenticationHeaderValue("Bearer", oauthToken);

            httpClient.DefaultRequestHeaders.Authorization = accessToken;

            var result = await httpClient.PostAsync(newUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<T> PostSignInAsync(object t, string url) {

            var newUrl = WebServiceUrl + "/" + url;

            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.PostAsync(newUrl, httpContent);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task<bool> PostSignUpAsync(object t, string url)
        {

            var newUrl = WebServiceUrl + "/" + url;

            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(newUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(int id, T t, string url) {

            var newUrl = WebServiceUrl + "/" + url + "/" + id;

            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var oauthToken = "";

            try
            {
                oauthToken = await SecureStorage.GetAsync("oauthtoken");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception ", ex);
            }

            var accessToken = new AuthenticationHeaderValue("Bearer", oauthToken);

            httpClient.DefaultRequestHeaders.Authorization = accessToken;

            var result = await httpClient.PutAsync(newUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string url) {

            var newUrl = WebServiceUrl + "/" + url;

            var httpClient = new HttpClient();

            var oauthToken = "";

            try
            {
                oauthToken = await SecureStorage.GetAsync("oauthtoken");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception ", ex);
            }

            var accessToken = new AuthenticationHeaderValue("Bearer", oauthToken);

            httpClient.DefaultRequestHeaders.Authorization = accessToken;

            var response = await httpClient.DeleteAsync(newUrl);

            return response.IsSuccessStatusCode;
        }
    }
}
