using IdentityService.Domain.Abstractions.Repositories;
using IdentityService.Domain.Abstractions.Services;
using IdentityService.Domain.Models;
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
        private readonly IJwtService _jwtService;

        #endregion

        public LoginUserCommandHandler(
            IPasswordService passwordService,
            IUserRepository userRepository,
            IJwtService jwtService)
        {
            _passwordService = passwordService;
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<BaseResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetUser(request.Email);

            Validate(user);

            bool result = await _passwordService.VerifyPassword(request.Password, user.Password);

            if (result)
            {
                string token = await _jwtService.GenerateToken(user);

                return await GetSuccessResult(DateTime.Now.ToShortDateString(), $"Аутентификация выполнена успешно: {token}");
            }

            return await GetBadResult(DateTime.Now.ToShortDateString(), "Неверный логин или пароль");
        }

        private void Validate(User user)
        {
            if (user is null)
                throw new ArgumentException("Пользователь не найден");
        }
    }
}
