using AutoMapper;
using Cafe.Application.Common.DTOs.Users;
using Cafe.Application.Usecases.Users.Queries.Requests;
using Cafe.Domain.Abstractions;
using MediatR;

namespace Cafe.Application.Usecases.Users.Queries.Handlers;

public class GetUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetUsersQueryRequest, List<ShortUserDto>>
{
    private readonly IUserRepository _userRepository = unitOfWork.UserRepository;

    public async Task<List<ShortUserDto>> Handle(GetUsersQueryRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);

        return mapper.Map<List<ShortUserDto>>(users);
    }
}
