﻿using AutoMapper;
using Cafe.Application.Common.DTOs.Prices;
using Cafe.Application.Usecases.Prices.Commands.Requests;
using Cafe.Domain.Entities;
using Cafe.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.Common.Mappers.Prices
{
    public class CreatePriceCommandToPrice : Profile
    {
        public CreatePriceCommandToPrice()
        {
            CreateMap<CreatePriceCommandRequest, Price>()
            .ForMember(dest => dest.Size, opt => opt.MapFrom(src => Size.FromString(src.SizeName))) // Преобразование строки в Size
            .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => Size.FromString(src.SizeName).Id)); // Установка SizeId
        }
    }
}