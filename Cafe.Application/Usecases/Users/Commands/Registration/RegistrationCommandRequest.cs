using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.Usecases.Users.Commands.Registration
{
    public class RegistrationCommandRequest : IRequest<RegistrationCommandResponse>
    {
        required public string Login { get; init; }

        required public string Name { get; init; }

        required public string Password { get; init; }

        required public DateTime DateOfBirth { get; init; }
    }
}
