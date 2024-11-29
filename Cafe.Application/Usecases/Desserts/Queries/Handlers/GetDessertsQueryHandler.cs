using AutoMapper;
using Cafe.Application.Common.DTOs.Desserts;
using Cafe.Application.Usecases.Desserts.Queries.Requests;
using Cafe.Domain.Abstractions;
using MediatR;

namespace Cafe.Application.Usecases.Desserts.Queries.Handlers;

internal class GetDessertsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetDessertsQueryRequest, List<ShortDessertDto>>
{
    readonly private IDessertRepository _dessertRepository = unitOfWork.DessertRepository;

    public async Task<List<ShortDessertDto>> Handle(GetDessertsQueryRequest request, CancellationToken cancellationToken)
    {
        var deserts = await _dessertRepository.GetAllAsync(cancellationToken);

        return mapper.Map<List<ShortDessertDto>>(deserts);
    }
}
