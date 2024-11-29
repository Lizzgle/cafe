using Cafe.Application.Common.DTOs.Users;
using MediatR;

namespace Cafe.Application.Usecases.Users.Queries.Requests;

public class GetUsersQueryRequest : IRequest<List<ShortUserDto>>
{
}
