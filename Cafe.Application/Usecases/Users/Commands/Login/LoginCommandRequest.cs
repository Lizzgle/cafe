using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.Usecases.Users.Commands.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        required public string Login { get; init; }

        required public string Password { get; init; }
    }
}
