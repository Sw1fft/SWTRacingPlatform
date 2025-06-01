using Autofac;
using FluentValidation;
using IdentityService.Application.Abstractions;
using IdentityService.Application.DTO_s.Request;
using IdentityService.Domain.Abstractions.Repositories;
using IdentityService.Domain.Abstractions.Services;
using IdentityService.Domain.Models;
using IdentityService.Infrastructure.Handlers.Commands;
using IdentityService.Infrastructure.Repositories;
using IdentityService.Infrastructure.Services;
using IdentityService.Infrastructure.Validators;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

namespace IdentityService.Infrastructure.IoC
{
    public class RegistrationService : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<LoginRequestValidator>()
                .As<IValidator<LoginRequestDto>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RegisterRequestValidator>()
                .As<IValidator<RegisterRequestDto>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserValidator>()
                .As<IValidator<User>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PasswordService>()
                .As<IPasswordService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();

            //var configuartion = MediatRConfigurationBuilder.Create(typeof(LoginUserCommand).Assembly)
            //    .WithAllOpenGenericHandlerTypesRegistered()
            //    .Build();

            //builder.RegisterMediatR(configuartion);

            var loginConfig = MediatRConfigurationBuilder
                .Create(typeof(LoginUserCommand).Assembly)
                .WithAllOpenGenericHandlerTypesRegistered()
                .Build();

            builder.RegisterMediatR(loginConfig);

            var registerConfig = MediatRConfigurationBuilder
                .Create(typeof(RegisterUserCommand).Assembly)
                .WithAllOpenGenericHandlerTypesRegistered()
                .Build();

            builder.RegisterMediatR(registerConfig);

            builder.RegisterType<JwtService>()
                .As<IJwtService>()
                .InstancePerLifetimeScope();
        }
    }
}
