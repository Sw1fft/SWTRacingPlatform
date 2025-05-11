using IdentityService.Domain.Models;
using IdentityService.Domain.Models.Base;
using MediatR;

namespace IdentityService.Infrastructure.Handlers.Commands
{
    public class RegisterUserCommand : IRequest<BaseResponse>
    {
        public User User { get; set; }

        public RegisterUserCommand(User user) 
        {
            User = user;
        }

        public override string ToString()
        {
            return $"User: {User}";
        }
    }
}
