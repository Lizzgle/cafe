using AutoMapper;
using Cafe.Application.Usecases.Drinks.Commands.Requests;
using Cafe.Presentation.Common.Requests.Drinks;

namespace Cafe.Presentation.Common.Mappers.Drinks;

public class UpdateDrinkRequestToUsecase : Profile
{
    public UpdateDrinkRequestToUsecase()
    {
        CreateMap<UpdateDrinkRequest, UpdateDrinkCommandRequest>();
    }
}
