using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Application.Errors
{
    public class RestException : Exception
    {
        public RestException(HttpStatusCode httpStatusCode, object erros = null)
        {
            _httpStatusCode = httpStatusCode;
        }
        public HttpStatusCode _httpStatusCode { get; }
    }
}
