using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFluentValidationTest.Model.Response
{
    public class ResponseHeader
    {
        public int StatusCode { get; set; }
        public int SubStatusCode { get; set; }
        public string Message { get; set; }
    }
}
