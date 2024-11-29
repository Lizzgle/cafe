using MediatR;

namespace Cafe.Application.Usecases.Feedbacks.Commands.Requests;

public class DeleteFeedbackCommandRequest : IRequest
{
    required public Guid Id { get; set; }
}
