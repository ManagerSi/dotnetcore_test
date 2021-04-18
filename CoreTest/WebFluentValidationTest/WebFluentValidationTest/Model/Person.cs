using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebFluentValidationTest.Model.Request;

namespace WebFluentValidationTest.Model
{
    public class Person : BaseRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public DateTime GetStartTime
        {
            get
            {
                if (DateTime.TryParseExact(this.StartTime, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out var startDate))
                {
                    return startDate;
                }

                return DateTime.MinValue;
            }
        }

        public DateTime GetEndTime
        {
            get
            {
                if (DateTime.TryParseExact(this.EndTime, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out var endDate))
                {
                    return endDate;
                }

                return DateTime.MinValue;
            }
        }
    }
}
