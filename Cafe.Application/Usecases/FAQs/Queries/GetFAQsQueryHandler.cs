using Cafe.Domain.Abstractions;
using Cafe.Domain.Entities;
using MediatR;

namespace Cafe.Application.Usecases.FAQs.Queries
{
    public class GetFAQsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetFAQsQueryRequest, List<FAQ>>
    {
        IFAQRepository _faqRepository = unitOfWork.FAQRepository;

        public Task<List<FAQ>> Handle(GetFAQsQueryRequest request, CancellationToken cancellationToken)
        {
            return _faqRepository.GetAllAsync(cancellationToken);
        }
    }
}
