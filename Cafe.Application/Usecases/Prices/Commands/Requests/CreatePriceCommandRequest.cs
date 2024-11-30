using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.Usecases.Prices.Commands.Requests
{
    public class CreatePriceCommandRequest : IRequest
    {
        required public Guid DrinkId { get; set; }

        required public string SizeName { get; set;}

        required public float Cost {  get; set; } 
    }
}
