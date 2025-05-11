using FluentValidation;
using IdentityService.Application.DTO_s.Request;

namespace IdentityService.Infrastructure.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.FirstName).MaximumLength(200);

            RuleFor(x => x.LastName).NotNull().NotEmpty();
            RuleFor(x => x.LastName).MaximumLength(200);

            RuleFor(x => x.Username).NotNull().NotEmpty();
            RuleFor(x => x.Username).MaximumLength(100);

            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x => x.Email).EmailAddress();

            RuleFor(x => x.Phone).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
            RuleFor(x => x.ConfirmPassword).NotNull().NotEmpty();
        }
    }
}
