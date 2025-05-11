using FluentValidation;
using IdentityService.Application.DTO_s.Request;
using IdentityService.Domain.Abstractions.Services;
using IdentityService.Domain.Models;
using IdentityService.Domain.Models.Base;
using IdentityService.Infrastructure.Handlers.Commands;
using IdentityService.Infrastructure.Services.Base;
using MediatR;

namespace IdentityService.Infrastructure.Services
{
    public class UserService : BaseService, IUserService
    {
        #region private

        private readonly IMediator _mediator;
        private readonly IValidator<LoginRequestDto> _loginRequestValidator;
        private readonly IValidator<RegisterRequestDto> _registerRequestValidator;

        #endregion

        public UserService(
            IMediator mediator, 
            IValidator<LoginRequestDto> loginRequestValidator,
            IValidator<RegisterRequestDto> registerRequestValidator)
        {
            _mediator = mediator;
            _loginRequestValidator = loginRequestValidator;
            _registerRequestValidator = registerRequestValidator;
        }

        public async Task<BaseResponse> LoginAsync(LoginRequestDto request)
        {
            try
            {
                RequestValidate(request);

                var result = await _mediator.Send(new LoginUserCommand(request.Email, request.Password));

                return await GetSuccessResult(result.Time, result.Message);
            }
            catch (ValidationException ex) { throw new ValidationException($"Ошибка валидации: {ex.Message}"); }
            catch (NullReferenceException) { throw new NullReferenceException("Невозможно выполнить операцию. Системная ошибка"); }
            catch (Exception ex) { throw new Exception($"Авторизация не выполнена. Ошибка: {ex.Message}"); }
        }

        public async Task<BaseResponse> RegisterAsync(RegisterRequestDto request)
        {
            try
            {
                RequestValidate(request);

                var user = new User()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Username = request.Username,
                    Email = request.Email,
                    Phone = request.Phone,
                    Password = request.Password,
                };

                var result = await _mediator.Send(new RegisterUserCommand(user));

                return await GetSuccessResult(result.Time, result.Message);
            }
            catch (ValidationException ex) { throw new ValidationException($"Ошибка валидации: {ex.Message}"); }
            catch (NullReferenceException) { throw new NullReferenceException("Невозможно выполнить операцию. Системная ошибка"); }
            catch (Exception ex) { throw new Exception($"Регистрация не выполнена. Ошибка: {ex.Message}"); }
        }

        private void RequestValidate(LoginRequestDto request)
        {
            var result = _loginRequestValidator.Validate(request);

            if (!result.IsValid)
                throw new ValidationException(result.ToString());
        }

        private void RequestValidate(RegisterRequestDto request)
        {
            var result = _registerRequestValidator.Validate(request);

            if (!result.IsValid)
                throw new ValidationException(result.ToString());
        }
    }
}
