using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using WebFluentValidationTest.Model;
using WebFluentValidationTest.Model.Request;

namespace WebFluentValidationTest.Validator
{
    public class RequestHeaderValidator : AbstractValidator<RequestHeader>
    {
        public RequestHeaderValidator()
        {
            RuleFor(x => x.RequestId).Cascade(CascadeMode.Stop).NotEmpty().Custom((id, context) =>
            {
                if (Guid.TryParse(id, out var guid))
                {
                    if (!guid.Equals(Guid.Empty)) return;
                }

                context.AddFailure(new ValidationFailure("RequestId",
                    "RequestId in RequestHeader can not format to guid."));
            });
        }
    }
}
