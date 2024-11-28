using MediatR;

namespace Cafe.Application.Usecases.Users.Commands.UpdateUser;

public class UpdateUserCommandRequest : IRequest
{
    required public Guid Id { get; set; }

    required public string Name { get; init; }

    required public DateTime DateOfBirth { get; init; }
}
