using FluentValidation;
using IdentityService.Domain.Models;

namespace IdentityService.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
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
        }
    }
}
