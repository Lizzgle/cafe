using Cafe.Application.Usecases.Feedbacks.Commands.Requests;
using Cafe.Domain.Abstractions;
using Event.Application.Common.Exceptions;
using MediatR;

namespace Cafe.Application.Usecases.Feedbacks.Commands.Handlers;

internal class DeleteFeedbackCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteFeedbackCommandRequest>
{
    private readonly IFeedbackRepository _feedbackRepository = unitOfWork.FeedbackRepository;

    public async Task Handle(DeleteFeedbackCommandRequest request, CancellationToken cancellationToken)
    {
        var feedback = await _feedbackRepository.GetByIdAsync(request.Id, cancellationToken);

        if (feedback is null)
        {
            throw new NotFoundException(ExceptionMessages.FeedbackNotFound);
        }

        await _feedbackRepository.DeleteAsync(feedback, cancellationToken);
    }
}
