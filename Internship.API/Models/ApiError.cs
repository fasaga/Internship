using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.API.Models
{
    public class ApiError
    {
        /// <summary>
        /// Error code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Contains information about the error.
        /// </summary>
        public string Description { get;  set; }

        /// <summary>
        /// Contains detailed information about the error.
        /// </summary>
        public string Message { get;  set; }

        public ApiError(int Code, string description)
        {
            this.Code = Code;
            Description = description;
        }

        public ApiError(int code, string description, string message)
        {
            Code = code;
            Description = description;
            Message = message;
        }

    }
}
