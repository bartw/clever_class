using Newtonsoft.Json;
using System.Net.Http;

namespace CleverClass.Common
{
    public static class ResponseMessage
    {
        public static void EnsureStatusCodeSuccessOrThrowException(this HttpResponseMessage message)
        {
            if (!message.IsSuccessStatusCode)
            {
                throw new HttpException
                {
                    StatusCode = message.StatusCode,
                    ReasonPhrase = message.ReasonPhrase,
                    Content = message.Content.ReadAsStringAsync().Result
                };
            }
        }

        public static T GetContentOrException<T>(this HttpResponseMessage message)
        {
            message.EnsureStatusCodeSuccessOrThrowException();
            var json = message.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
