using Cafe.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.Usecases.FAQs.Queries
{
    public class GetFAQsQueryRequest : IRequest<List<FAQ>>
    {
    }
}
