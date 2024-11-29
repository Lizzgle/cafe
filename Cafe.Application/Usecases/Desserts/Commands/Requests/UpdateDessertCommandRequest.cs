using MediatR;

namespace Cafe.Application.Usecases.Desserts.Commands.Requests;

public class UpdateDessertCommandRequest : IRequest
{
    required public Guid Id { get; set; }

    required public string Name { get; set; }

    public string Description { get; set; }

    required public int Calories { get; set; }

    required public float Price { get; set; }
}
