﻿using AutoMapper;
using Cafe.Application.Common.DTOs.Desserts;
using Cafe.Domain.Entities;

namespace Cafe.Application.Common.Mappers.Desserts;

public class DessertToDessertDto : Profile
{
    public DessertToDessertDto()
    {
        CreateMap<Dessert, DessertDto>()
            .ForMember(d => d.Ingredients, opt => opt.MapFrom(d => d.Ingredients.Select(i => i.Name)));
    }
}
