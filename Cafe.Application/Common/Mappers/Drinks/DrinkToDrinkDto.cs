using AutoMapper;
using Cafe.Application.Common.DTOs.Drinks;
using Cafe.Domain.Entities;

namespace Cafe.Application.Common.Mappers.Drinks;

public class DrinkToDrinkDto : Profile
{
    public DrinkToDrinkDto()
    {
        CreateMap<Drink, DrinkDto>()
            .ForMember(f => f.CategoryName, opt => opt.MapFrom(f => f.Category.Name))
            .ForMember(d => d.Ingredients, opt => opt.MapFrom(d => d.Ingredients.Select(i => i.Name)));
    }
}
