using AutoMapper;
using Cafe.Application.Common.DTOs.Feedbacks;
using Cafe.Application.Usecases.Feedbacks.Queries.Requests;
using Cafe.Domain.Abstractions;
using MediatR;

namespace Cafe.Application.Usecases.Feedbacks.Queries.Handlers;

internal class GetFeedbacksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetFeedbacksQueryRequest, List<ShortFeedbackDto>>
{
    private readonly IFeedbackRepository _feedbackRepository = unitOfWork.FeedbackRepository;
    private readonly IUserRepository _userRepository = unitOfWork.UserRepository;

    public async Task<List<ShortFeedbackDto>> Handle(GetFeedbacksQueryRequest request, CancellationToken cancellationToken)
    {
        var feedbacks = await _feedbackRepository.GetAllAsync(cancellationToken);

        foreach (var feedback in feedbacks)
        {
            feedback.User = await _userRepository.GetByIdAsync(feedback.UserId, cancellationToken);
        }
       
        return mapper.Map<List<ShortFeedbackDto>>(feedbacks);
    }
}
