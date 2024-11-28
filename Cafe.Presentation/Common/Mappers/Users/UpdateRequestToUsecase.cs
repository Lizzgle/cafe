using AutoMapper;
using Cafe.Application.Usecases.Users.Commands.UpdateUser;
using Cafe.Presentation.Common.Requests.Users;

namespace Cafe.Presentation.Common.Mappers.Users;

public class UpdateRequestToUsecase : Profile
{
    public UpdateRequestToUsecase()
    {
        CreateMap<UpdateRequest, UpdateUserCommandRequest>();
    }
}
