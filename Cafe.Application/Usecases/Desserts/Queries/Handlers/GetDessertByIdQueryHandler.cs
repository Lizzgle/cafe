using AutoMapper;
using Cafe.Application.Common.DTOs.Desserts;
using Cafe.Application.Usecases.Desserts.Queries.Requests;
using Cafe.Domain.Abstractions;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Desserts.Queries.Handlers;

public class GetDessertByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetDessertByIdQueryRequest, DessertDto>
{
    readonly private IDessertRepository _dessertRepository = unitOfWork.DessertRepository;

    public async Task<DessertDto> Handle(GetDessertByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var dessert = await _dessertRepository.GetByIdAsync(request.Id);

        if (dessert == null)
        {
            throw new NotFoundException(ExceptionMessages.DessertNotFound);
        }

        return mapper.Map<DessertDto>(dessert);
    }
}
