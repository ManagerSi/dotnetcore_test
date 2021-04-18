using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using WebFluentValidationTest.Model;

namespace WebFluentValidationTest.Validator
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            //遇到错误是否继续验证，stop是立即停止并返回
            CascadeMode = CascadeMode.Continue;

            //baseRequest
            //RuleFor()

            RuleFor(x => x.Id).NotEqual(0);
            RuleFor(x => x.Name).Length(0, 10);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Age).InclusiveBetween(18, 160);

            //当时间不为空时，验证时间
            When(x => !string.IsNullOrWhiteSpace(x.StartTime) || !string.IsNullOrWhiteSpace(x.EndTime), () =>
                {
                    RuleFor(x => x.StartTime).NotEmpty();
                    RuleFor(x => x.EndTime).NotEmpty();

                });
        }

        protected override bool PreValidate(ValidationContext<Person> context, ValidationResult result)
        {
            if (!base.PreValidate(context, result)) return false;//do not continue to validate

            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure($"{nameof(Person)}", "Please ensure {PropertyName} was supplied."));
                return false;//do not continue to validate
            }
            return true;
        }
    }

}
