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
            _erros = erros;
        }
        public HttpStatusCode _httpStatusCode { get; }
        public object _erros { get; set; }
    }
}
