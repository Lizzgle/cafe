using Cafe.Application.Usecases.Users.Commands.Requests;
using Cafe.Domain.Abstractions;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Users.Commands.Handlers;

public class DeleteUserCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteUserCommandRequest>
{
    private readonly IUserRepository _userRepository = unitOfWork.UserRepository;

    public async Task Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.Id);

        if (user is null)
        {
            throw new NotFoundException(ExceptionMessages.UserNotFound);
        }

        await _userRepository.DeleteUserAsync(user);
    }
}
