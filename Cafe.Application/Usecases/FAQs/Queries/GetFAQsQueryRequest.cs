using Cafe.Domain.Entities;
using MediatR;

namespace Cafe.Application.Usecases.FAQs.Queries;

public class GetFAQsQueryRequest : IRequest<List<FAQ>>
{
}
