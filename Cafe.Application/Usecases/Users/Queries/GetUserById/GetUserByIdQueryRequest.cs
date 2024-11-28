using Cafe.Application.Common.DTOs.Users;
using MediatR;

namespace Cafe.Application.Usecases.Users.Queries.GetByIdUser;

public class GetUserByIdQueryRequest : IRequest<UserDto>
{
    required public Guid Id { get; init; }
}
