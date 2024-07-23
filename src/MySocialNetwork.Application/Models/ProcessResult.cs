using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Application.Models
{
    public class ProcessResult<T> where T : class
    {
        public ProcessResult(T payload)
        {
            Payload = payload;
            Errors = [];
        }
        public ProcessResult()
        {
            Errors = [];
        }
        public T Payload { get; set; }
        public bool IsError { get; set; }
        public List<Error> Errors { get; set; }
    }
}
