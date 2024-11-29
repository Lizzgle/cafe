using AutoMapper;
using Cafe.Application.Usecases.Feedbacks.Commands.Requests;
using Cafe.Domain.Entities;

namespace Cafe.Application.Common.Mappers.Feedbacks;

public class CreateFeedbackCommandRequestToFeedback : Profile
{
    public CreateFeedbackCommandRequestToFeedback()
    {
        CreateMap<CreateFeedbackCommandRequest, Feedback>();
    }
}
