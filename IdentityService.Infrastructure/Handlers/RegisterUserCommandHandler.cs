using FluentValidation;
using IdentityService.Domain.Abstractions.Repositories;
using IdentityService.Domain.Models;
using IdentityService.Domain.Models.Base;
using IdentityService.Infrastructure.Handlers.Commands;
using MediatR;

namespace IdentityService.Infrastructure.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, BaseResponse>
    {
        #region private

        private readonly IUserRepository _userRepository;
        private readonly IValidator<User> _userValidator;

        #endregion

        public RegisterUserCommandHandler(IUserRepository userRepository, IValidator<User> userValidator)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        public async Task<BaseResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            UserValidator(request.User);

            var result = await _userRepository.CreateUser(request.User);

            return result;
        }

        private void UserValidator(User user)
        {
            var result = _userValidator.Validate(user);

            if (!result.IsValid)
                throw new ValidationException(result.ToString());
        }
    }
}
