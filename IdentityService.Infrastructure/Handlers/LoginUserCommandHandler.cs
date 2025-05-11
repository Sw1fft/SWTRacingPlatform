using IdentityService.Domain.Abstractions.Repositories;
using IdentityService.Domain.Abstractions.Services;
using IdentityService.Domain.Models.Base;
using IdentityService.Infrastructure.Handlers.Commands;
using IdentityService.Infrastructure.Services.Base;
using MediatR;

namespace IdentityService.Infrastructure.Handlers
{
    public class LoginUserCommandHandler : BaseService, IRequestHandler<LoginUserCommand, BaseResponse>
    {
        #region private

        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepository;

        #endregion

        public LoginUserCommandHandler(IPasswordService passwordService, IUserRepository userRepository)
        {
            _passwordService = passwordService;
            _userRepository = userRepository;
        }

        public async Task<BaseResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            string passwordHash = await _userRepository.GetUserPasswordHash(request.Email);

            bool result = await _passwordService.VerifyPassword(request.Password, passwordHash);

            if (result)
            {


                return await GetSuccessResult(DateTime.Now.ToShortDateString(), "Аутентификация выполнена успешно");
            }

            return await GetBadResult(DateTime.Now.ToShortDateString(), "Неверный логин или пароль");
        }
    }
}
