using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Exceptions
{
    public class FluentValidationException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }

        public FluentValidationException()
        : base("Uma ou mais falhas de validação ocorreram.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public FluentValidationException(IEnumerable<ValidationFailure> failures)
       : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
    }
}
