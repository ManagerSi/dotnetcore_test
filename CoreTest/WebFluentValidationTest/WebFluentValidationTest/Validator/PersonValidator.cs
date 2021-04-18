using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using WebFluentValidationTest.Model;

namespace WebFluentValidationTest.Validator
{
    /// <summary>
    /// https://docs.fluentvalidation.net/en/latest/built-in-validators.html
    /// </summary>
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            //遇到错误是否继续验证，stop是立即停止并返回
            CascadeMode = CascadeMode.Continue;

            //baseRequest
            RuleFor(x => x.Header).SetValidator(new RequestHeaderValidator());
            RuleFor(x => x.Program).Must(x => x.Equals("jerry", StringComparison.InvariantCultureIgnoreCase));
            

            RuleFor(x => x.Id).NotEqual(0);
            RuleFor(x => x.Name).Length(0, 10);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Age).InclusiveBetween(18, 160);

            //当时间不为空时，才验证时间
            When(x => !string.IsNullOrWhiteSpace(x.StartTime) || !string.IsNullOrWhiteSpace(x.EndTime), () =>
                {
                    RuleFor(x => x.StartTime).Cascade(CascadeMode.Stop).NotEmpty().DependentRules(()=>
                    {
                        RuleFor(x => x.GetStartTime).Cascade(CascadeMode.Stop).NotEqual(DateTime.MinValue)
                                .WithName("StartTime").WithMessage("{PropertyName} can not format to DateTime.");
                    });

                    RuleFor(x => x.EndTime).Cascade(CascadeMode.Stop).NotEmpty().DependentRules(() =>
                    {
                        RuleFor(x => x.GetEndTime).Cascade(CascadeMode.Stop).NotEqual(DateTime.MinValue)
                            .WithName("EndTime").WithMessage("{PropertyName} can not format to DateTime.");
                    });

                    //RuleFor(x => x.GetStartTime).Must((person, startTime) => startTime.CompareTo(person.GetEndTime)<0)
                    //    .WithMessage("StartTime must less than EndTime");
                    RuleFor(x => x.GetStartTime).LessThan(x=>x.GetEndTime)
                        .WithMessage("StartTime must less than EndTime");
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
