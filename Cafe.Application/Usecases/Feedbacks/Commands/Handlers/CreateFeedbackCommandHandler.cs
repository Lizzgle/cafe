using AutoMapper;
using Cafe.Application.Usecases.Feedbacks.Commands.Requests;
using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using MediatR;

namespace Cafe.Application.Usecases.Feedbacks.Commands.Handlers;

public class CreateFeedbackCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateFeedbackCommandRequest>
{
    private readonly IFeedbackRepository _feedbackRepository = unitOfWork.FeedbackRepository;

    public async Task Handle(CreateFeedbackCommandRequest request, CancellationToken cancellationToken)
    {
        var feedback = mapper.Map<Feedback>(request);

        feedback.Date = DateTime.UtcNow;

        await _feedbackRepository.CreateAsync(feedback);
    }
}
