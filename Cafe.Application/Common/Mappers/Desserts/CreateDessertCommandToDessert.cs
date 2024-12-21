using AutoMapper;
using Cafe.Application.Usecases.Desserts.Commands.Requests;
using Cafe.Domain.Entities;

namespace Cafe.Application.Common.Mappers.Desserts;

public class CreateDessertCommandToDessert : Profile
{
    public CreateDessertCommandToDessert()
    {
        CreateMap<CreateDessertCommandRequest, Dessert>()
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src =>
                src.Ingredients.Select(name => new Ingredient { Name = name }).ToList()));
    }
}
