using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebFluentValidationTest.Model.Request
{
    public class RequestHeader
    {
        [JsonProperty("requestId")]
        public string RequestId { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }

        [NotMapped]
        [JsonProperty("options")]
        public Dictionary<string,string> Options { get; set; }
    }
}
