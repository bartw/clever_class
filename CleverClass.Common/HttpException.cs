using System;
using System.Net;

namespace CleverClass.Common
{
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        public string Content { get; set; }

        public override string Message
        {
            get
            {
                return string.Format("Request failed: {0} - {1}\n{2}\n", StatusCode, ReasonPhrase, Content);
            }
        }
    }
}
