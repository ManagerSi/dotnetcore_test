using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebFluentValidationTest.Model.Request
{
    public class BaseRequest
    {
        [JsonProperty("program")]
        public string Program { get; set; }

        [JsonProperty("header")]
        public RequestHeader Header { get; set; }
    }
}
