using Cafe.Domain.Abstractions;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateUserCommandRequest>
{
    private readonly IUserRepository _userRepository = unitOfWork.UserRepository;

    public async Task Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.Id);

        if (user is null)
        {
            throw new NotFoundException(ExceptionMessages.UserNotFound);
        }

        user.Name = request.Name;
        user.DateOfBirth = request.DateOfBirth;

        await _userRepository.UpdateUserAsync(user);

    }
}
