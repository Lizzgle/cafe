using AutoMapper;
using Cafe.Application.Usecases.Desserts.Commands.Requests;
using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Desserts.Commands.Handlers;

public class CreateDessertCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateDessertCommandRequest>
{
    readonly private IDessertRepository _dessertRepository = unitOfWork.DessertRepository;

    public async Task Handle(CreateDessertCommandRequest request, CancellationToken cancellationToken)
    {
        if(await _dessertRepository.GetDessertByName(request.Name, cancellationToken) is not null)
        {
            throw new AlreadyExistsException(ExceptionMessages.DessertAlreadyExists);
        }

        var dessert = mapper.Map<Dessert>(request);

        await _dessertRepository.CreateAsync(dessert, cancellationToken);
    }
}
