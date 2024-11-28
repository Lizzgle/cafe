using AutoMapper;
using Cafe.Application.Common.Providers;
using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Users.Commands.Registration;

public class RegistrationCommandHandler(IUnitOfWork unitOfWork, IJwtProvider jwtProvider, IMapper mapper)
    : IRequestHandler<RegistrationCommandRequest, RegistrationCommandResponse>
{
    private readonly IUserRepository _userRepository = unitOfWork.UserRepository;

    public async Task<RegistrationCommandResponse> Handle(RegistrationCommandRequest request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByLogin(request.Login) is not null)
        {
            throw new NotFoundException(ExceptionMessages.UserAlreadyExists);
        }

        var user = mapper.Map<User>(request);

        await _userRepository.CreateUserAsync(user);

        user.Roles.Add(Role.Client);

        string jwt = jwtProvider.GenerateJwt(user);
        string refresh = jwtProvider.GenerateRefreshToken();

        user.RefreshToken = refresh;
        user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(1);

        await _userRepository.UpdateUserAsync(user, cancellationToken);

        return new() { JwtToken = jwt, RefreshToken = refresh };
    }
}
