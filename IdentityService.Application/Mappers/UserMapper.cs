using AutoMapper;
using IdentityService.Domain.Entities;
using IdentityService.Domain.Models;

namespace IdentityService.Application.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserEntity, User>().ReverseMap();
        }
    }
}
