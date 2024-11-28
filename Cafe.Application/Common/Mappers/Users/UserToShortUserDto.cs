using AutoMapper;
using Cafe.Application.Common.DTOs.Users;
using Cafe.Domain.Entities;

namespace Cafe.Application.Common.Mappers.Users;

public class UserToShortUserDto : Profile
{
    public UserToShortUserDto()
    {
        CreateMap<User, ShortUserDto>();
    }
}
