using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.Usecases.Users.Commands.Login
{
    public class LoginCommandResponse
    {
        public string JwtToken { get; init; } = string.Empty;

        public string RefreshToken { get; init; } = string.Empty;
    }
}
