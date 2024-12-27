using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.Usecases.Desserts.Commands.Requests
{
    public class RemoveIngredientFromDessertCommandRequest : IRequest
    {
        public string Name { get; set; }

        public Guid DessertId { get; set; }
    }
}
