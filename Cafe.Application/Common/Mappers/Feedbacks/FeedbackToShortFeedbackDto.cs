using AutoMapper;
using Cafe.Application.Common.DTOs.Feedbacks;
using Cafe.Domain.Entities;

namespace Cafe.Application.Common.Mappers.Feedbacks;

public class FeedbackToShortFeedbackDto : Profile
{
    public FeedbackToShortFeedbackDto()
    {
        CreateMap<Feedback, ShortFeedbackDto>()
            .ForMember(f => f.UserName, opt => opt.MapFrom(f => f.User.Name));
    }
}
