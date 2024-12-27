using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.Usecases.Categories.Queries.Requests;

public class GetCategoriesQueryRequest : IRequest<List<string>>
{
}
