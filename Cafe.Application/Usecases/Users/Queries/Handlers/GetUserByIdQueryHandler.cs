﻿using AutoMapper;
using Cafe.Application.Common.DTOs.Users;
using Cafe.Application.Usecases.Users.Queries.Requests;
using Cafe.Domain.Abstractions;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Users.Queries.Handlers;

public class GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetUserByIdQueryRequest, UserDto>
{
    private readonly IUserRepository _userRepository = unitOfWork.UserRepository;

    public async Task<UserDto> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user == null)
        {
            throw new NotFoundException(ExceptionMessages.UserNotFound);
        }

        return mapper.Map<UserDto>(user);
    }
}
