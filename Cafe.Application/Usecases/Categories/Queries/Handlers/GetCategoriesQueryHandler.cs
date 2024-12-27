using Cafe.Application.Usecases.Categories.Queries.Requests;
using Cafe.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.Usecases.Categories.Queries.Handlers
{
    public class GetCategoriesQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetCategoriesQueryRequest, List<string>>
    {

        async Task<List<string>> IRequestHandler<GetCategoriesQueryRequest, List<string>>.Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await unitOfWork.CategoryRepository.GetAllAsync(cancellationToken);

            return categories.Select(c => c.Name).ToList();
        }
    }
}
