using MediatR;

namespace Cafe.Application.Usecases.Feedbacks.Commands.Requests;

public class CreateFeedbackCommandRequest : IRequest
{
    required public int Rating { get; set; }

    public string? Description { get; set; }

    required public Guid UserId { get; set; }
}
