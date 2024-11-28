using AutoMapper;
using Cafe.Presentation.Common.Requests.Users;
using Events.Application.Users.Commands.RefreshToken;

namespace Cafe.Presentation.Common.Mappers.Users
{
    public class RefreshTokenRequestToUsecase : Profile
    {
        public RefreshTokenRequestToUsecase()
        {
            CreateMap<RefreshTokenRequest, RefreshTokenCommandRequest>();
        }
    }
}
