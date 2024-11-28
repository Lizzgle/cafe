using Cafe.Application.Common.DTOs.Users;
using MediatR;

namespace Cafe.Application.Usecases.Users.Queries.GetUsers;

public class GetUsersQueryRequest : IRequest<List<ShortUserDto>>
{
}
