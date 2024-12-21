using AutoMapper;
using Cafe.Application.Usecases.Prices.Commands.Requests;
using Cafe.Presentation.Common.Requests.Prices;

namespace Cafe.Presentation.Common.Mappers.Prices;

public class CreatePriceRequestToUsecase : Profile
{
    public CreatePriceRequestToUsecase()
    {
        CreateMap<CreatePriceRequest, CreatePriceCommandRequest>();
    }
}
