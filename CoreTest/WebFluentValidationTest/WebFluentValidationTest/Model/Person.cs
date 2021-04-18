using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFluentValidationTest.Model.Request;

namespace WebFluentValidationTest.Model
{
    public class Person:BaseRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
