using Cafe.Domain.Entities;

namespace Cafe.Domain.Abstractions;

public interface IIngredientRepository : IBaseRepository<Ingredient>
{
    Task<Ingredient?> GetIngredientByName(string name, CancellationToken token = default);
}
