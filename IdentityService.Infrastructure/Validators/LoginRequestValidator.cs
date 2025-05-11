using FluentValidation;
using IdentityService.Application.DTO_s.Request;

namespace IdentityService.Infrastructure.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Получены некорректные данные");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Неверный формат электронной почты");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Получены некорректные данные");
        }
    }
}
