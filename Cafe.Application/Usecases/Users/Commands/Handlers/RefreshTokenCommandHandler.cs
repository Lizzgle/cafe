using Cafe.Application.Common.Exceptions;
using Cafe.Application.Common.Providers;
using Cafe.Application.Usecases.Users.Commands.Requests;
using Cafe.Application.Usecases.Users.Commands.Responses;
using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using Event.Application.Common.Exceptions;
using MediatR;
using System.Security.Claims;

namespace Cafe.Application.Usecases.Users.Commands.Handlers;

public class RefreshTokenCommandHandler(IUnitOfWork unitOfWork, IJwtProvider jwtProvider)
    : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
{
    private readonly IUserRepository _userRepository = unitOfWork.UserRepository;

    public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
    {
        ClaimsPrincipal? principal = jwtProvider.GetClaimsPrincipal(request.Jwt);

        Claim? id = principal?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

        if (id is null || !Guid.TryParse(id.Value, out Guid guidId))
        {
            throw new InvalidTokenException(ExceptionMessages.InvalidDataInToken);
        }

        User? user = await _userRepository.GetByIdAsync(guidId, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException(ExceptionMessages.UserNotFound);
        }

        if (user.RefreshToken is null
                || user.RefreshToken != request.RefreshToken
                || user.RefreshTokenExpiry < DateTime.UtcNow)
        {
            user.RefreshToken = null;
            user.RefreshTokenExpiry = null;

            await _userRepository.UpdateAsync(user, cancellationToken);

            throw new InvalidTokenException(ExceptionMessages.RefreshTokenIsNotValid);
        }

        string jwt = jwtProvider.GenerateJwt(user);

        return new() { Jwt = jwt, RefreshToken = user.RefreshToken! };
    }
}
