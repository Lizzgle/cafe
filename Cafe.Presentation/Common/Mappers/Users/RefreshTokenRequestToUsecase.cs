using AutoMapper;
using Cafe.Application.Usecases.Users.Commands.Requests;
using Cafe.Presentation.Common.Requests.Users;

namespace Cafe.Presentation.Common.Mappers.Users;

public class RefreshTokenRequestToUsecase : Profile
{
    public RefreshTokenRequestToUsecase()
    {
        CreateMap<RefreshTokenRequest, RefreshTokenCommandRequest>();
    }
}
