using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Domain.Bases
{
    public class BaseHttpResponse<T>
    {
        public HttpStatusCode StatusCode { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }
        public IDictionary<string, string[]> Errors { get; private set; }


        public BaseHttpResponse(object data, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            StatusCode = statusCode;
            Data = data;
        }

        public BaseHttpResponse(string message, IEnumerable<ValidationFailure> failures, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            StatusCode = statusCode;
            Message = message;
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public BaseHttpResponse(string message, object data, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }


    }
}
