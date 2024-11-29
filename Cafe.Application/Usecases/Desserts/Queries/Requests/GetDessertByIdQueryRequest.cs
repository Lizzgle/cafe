using Cafe.Application.Common.DTOs.Desserts;
using MediatR;

namespace Cafe.Application.Usecases.Desserts.Queries.Requests;

public class GetDessertByIdQueryRequest : IRequest<DessertDto>
{
    required public Guid Id { get; set; }
}
