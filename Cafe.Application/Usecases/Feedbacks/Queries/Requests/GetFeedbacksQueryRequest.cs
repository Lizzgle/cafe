using Cafe.Application.Common.DTOs.Feedbacks;
using MediatR;

namespace Cafe.Application.Usecases.Feedbacks.Queries.Requests;

public class GetFeedbacksQueryRequest : IRequest<List<ShortFeedbackDto>>
{
}
