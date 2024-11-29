using Cafe.Application.Common.Providers;
using Cafe.Application.Usecases.Users.Commands.Requests;
using Cafe.Application.Usecases.Users.Commands.Responses;
using Cafe.Domain.Abstractions;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Users.Commands.Handlers;

public class LoginCommandHandler(IUnitOfWork unitOfWork, IJwtProvider jwtProvider)
    : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    private readonly IUserRepository _userRepository = unitOfWork.UserRepository;

    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByLoginAndPassword(request.Login, request.Password, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(ExceptionMessages.UserNotFound);
        }

        string jwt = jwtProvider.GenerateJwt(user);
        string refresh = jwtProvider.GenerateRefreshToken();

        user.RefreshToken = refresh;
        user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(1);

        await _userRepository.UpdateAsync(user, cancellationToken);

        return new() { JwtToken = jwt, RefreshToken = refresh };
    }
}
