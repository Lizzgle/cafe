using AutoMapper;
using Cafe.Application.Common.DTOs.Prices;
using Cafe.Domain.Entities;
using Cafe.Domain.Enums;

namespace Cafe.Application.Common.Mappers.Prices;

public class PriceDtoToPrice : Profile
{
    public PriceDtoToPrice() 
    {
        CreateMap<PriceDto, Price>()
        .ForMember(dest => dest.Size, opt => opt.MapFrom(src => Size.FromString(src.SizeName))) // Преобразование строки в Size
        .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => Size.FromString(src.SizeName).Id)); // Установка SizeId
    }
}
