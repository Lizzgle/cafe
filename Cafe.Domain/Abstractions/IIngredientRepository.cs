using Cafe.Domain.Entities;

namespace Cafe.Domain.Abstractions;

public interface IIngredientRepository : IBaseRepository<Ingredient>
{
    Task<Ingredient?> GetIngredientByName(string name, CancellationToken token = default);

    Task AddIngredientToDrink(Guid drinkId, Guid ingredientId, CancellationToken token = default);

    Task AddIngredientToDessert(Guid dessertId, Guid ingredientId, CancellationToken token = default);
}
