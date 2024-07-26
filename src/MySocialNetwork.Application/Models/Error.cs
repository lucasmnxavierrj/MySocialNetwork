using MySocialNetwork.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Application.Models
{
    public class Error
    {
        public Error()
        {
        }
        public Error(ErrorCode code, string message)
        {
            Code = code;
            Message = message;
        }
        public ErrorCode Code { get; set; }
        public string Message { get; set; }
    }
}
