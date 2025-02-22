﻿using AutoMapper;
using Cafe.Application.Usecases.Users.Commands.Requests;
using Cafe.Domain.Entities;

namespace Cafe.Application.Common.Mappers.Users;

public class RegistrationCommandRequestToUser : Profile
{
    public RegistrationCommandRequestToUser()
    {
        CreateMap<RegistrationCommandRequest, User>();
    }
}
