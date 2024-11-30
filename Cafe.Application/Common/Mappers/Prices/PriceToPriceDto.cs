using AutoMapper;
using Cafe.Application.Common.DTOs.Prices;
using Cafe.Domain.Entities;

namespace Cafe.Application.Common.Mappers.Prices;

public class PriceToPriceDto : Profile
{
    public PriceToPriceDto()
    {
        CreateMap<Price, PriceDto>()
        .ForMember(dest => dest.SizeName, opt => opt.MapFrom(p => p.Size.Name))
        .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.Cost));
    }
}
