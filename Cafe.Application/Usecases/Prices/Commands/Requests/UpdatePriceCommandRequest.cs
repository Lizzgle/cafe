using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.Usecases.Prices.Commands.Requests
{
    public class UpdatePriceCommandRequest : IRequest
    {
        required public Guid Id { get; set; }

        required public float Cost { get; set; }
    }
}
