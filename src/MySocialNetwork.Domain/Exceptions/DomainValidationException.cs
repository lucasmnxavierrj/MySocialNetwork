using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Exceptions
{
    public class DomainValidationException : Exception
    {
        public List<string> ValidationErrors { get; set; } = [];
        public DomainValidationException(string message) : base(message)
        {
        }
        public DomainValidationException(string message, List<string> validationErrors) : base(message)
        {
            ValidationErrors = validationErrors;
        }
    }
}
