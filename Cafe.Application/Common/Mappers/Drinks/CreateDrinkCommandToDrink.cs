using AutoMapper;
using Cafe.Application.Usecases.Drinks.Commands.Requests;
using Cafe.Domain.Entities;

namespace Cafe.Application.Common.Mappers.Drinks;

public class CreateDrinkCommandToDrink : Profile
{
    public CreateDrinkCommandToDrink()
    {
        CreateMap<CreateDrinkCommandRequest, Drink>()
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src =>
                src.Ingredients.Select(name => new Ingredient { Name = name }).ToList()));
    }
}
