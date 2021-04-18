using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebFluentValidationTest.Model.Response;

namespace WebFluentValidationTest.Filter
{
    public class BadRequestResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is BadRequestObjectResult)
            {
                BadRequestObjectResult res = (BadRequestObjectResult)context.Result;
                ValidationProblemDetails pd = res.Value as ValidationProblemDetails;

                StringBuilder sb = new StringBuilder();
                foreach (var item in pd.Errors)
                {
                    sb.AppendLine($"{item.Key}:{string.Join(';', item.Value)}");
                }

                context.Result = new JsonResult(
                    new BaseResponse
                    {
                        Header = new ResponseHeader()
                        {
                            StatusCode = 400,
                            SubStatusCode = 401,
                            Message = sb
                                .ToString(), //string.Join(",", errors.Select(e => string.Format("{0}", e)).ToList()),

                        }
                    });

                return;
            }
        }
    }
}
