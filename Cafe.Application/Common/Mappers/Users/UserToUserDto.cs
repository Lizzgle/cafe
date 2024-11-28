using AutoMapper;
using Cafe.Application.Common.DTOs.Users;
using Cafe.Domain.Entities;

namespace Cafe.Application.Common.Mappers.Users;

public class UserToUserDto : Profile
{
    public UserToUserDto() 
    {
        CreateMap<User, UserDto>();
    }
}
