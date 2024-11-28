using AutoMapper;
using Cafe.Application.Usecases.Users.Commands.Registration;
using Cafe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.Common.Mappers.Users
{
    public class RegistrationCommandRequestToUser : Profile
    {
        public RegistrationCommandRequestToUser()
        {
            CreateMap<RegistrationCommandRequest, User>();
        }
    }
}
