using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CleverClass.Common
{
    public abstract class RestClient : IDisposable
    {
        private readonly Uri _baseUri;
        private readonly HttpClient _client;

        protected RestClient(Uri baseUri)
        {
            _baseUri = baseUri;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.Timeout = new TimeSpan(0, 0, 30);
        }

        protected T Get<T>(string path)
        {
            var response = _client.GetAsync(string.Format("{0}/{1}", _baseUri.AbsoluteUri, path)).Result;
            return response.GetContentOrException<T>();
        }

        protected R Post<T, R>(string path, T data)
        {
            var response = _client.PostAsync(string.Format("{0}/{1}", _baseUri.AbsoluteUri, path), new StringContent(SerializeObject(data), Encoding.UTF8, "application/json")).Result;
            return response.GetContentOrException<R>();
        }

        protected R Put<T, R>(string path, T data)
        {
            var response = _client.PutAsync(string.Format("{0}/{1}", _baseUri.AbsoluteUri, path), new StringContent(SerializeObject(data), Encoding.UTF8, "application/json")).Result;
            return response.GetContentOrException<R>();
        }

        protected void Delete(string path)
        {
            var response = _client.DeleteAsync(string.Format("{0}/{1}", _baseUri.AbsoluteUri, path)).Result;
            response.EnsureStatusCodeSuccessOrThrowException();
        }

        private static string SerializeObject<T>(T data)
        {
            return JsonConvert.SerializeObject(data, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
