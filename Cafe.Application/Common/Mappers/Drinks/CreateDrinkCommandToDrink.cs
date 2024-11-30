using AutoMapper;
using Cafe.Application.Usecases.Drinks.Commands.Requests;
using Cafe.Domain.Entities;

namespace Cafe.Application.Common.Mappers.Drinks;

public class CreateDrinkCommandToDrink : Profile
{
    public CreateDrinkCommandToDrink()
    {
        CreateMap<CreateDrinkCommandRequest, Drink>();
    }
}
