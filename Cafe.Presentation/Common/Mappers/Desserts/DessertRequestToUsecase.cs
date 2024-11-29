using AutoMapper;
using Cafe.Application.Usecases.Desserts.Commands.Requests;
using Cafe.Presentation.Common.Requests.Desserts;

namespace Cafe.Presentation.Common.Mappers.Desserts;

public class DessertRequestToUsecase : Profile
{
    public DessertRequestToUsecase()
    {
        CreateMap<DessertRequest, CreateDessertCommandRequest>();

        CreateMap<DessertRequest, UpdateDessertCommandRequest>();
    }
}
