using AutoMapper;
using Cafe.Application.Usecases.Feedbacks.Commands.Requests;
using Cafe.Presentation.Common.Requests.Feedbacks;

namespace Cafe.Presentation.Common.Mappers.Feedbacks;

public class CreateFeedbackRequestToUsecase : Profile
{
    public CreateFeedbackRequestToUsecase()
    {
        CreateMap<CreateFeedbackRequest, CreateFeedbackCommandRequest>();
    }
}
