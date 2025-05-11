using IdentityService.Domain.Models.Base;
using MediatR;

namespace IdentityService.Infrastructure.Handlers.Commands
{
    public class LoginUserCommand : IRequest<BaseResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return $"Email: {Email}, Password: {Password}";
        }
    }
}
