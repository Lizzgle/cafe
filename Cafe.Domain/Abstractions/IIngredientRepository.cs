using Cafe.Domain.Entities;

namespace Cafe.Domain.Abstractions;

public interface IIngredientRepository : IBaseRepository<Ingredient>
{
    Task<Ingredient?> GetIngredientByName(string name, CancellationToken token = default);

    Task AddIngredientToDrink(Guid drinkId, Guid ingredientId, CancellationToken token = default);

    Task AddIngredientToDessert(Guid dessertId, Guid ingredientId, CancellationToken token = default);

    Task RemoveIngredientFroDrink(Guid drinkId, Guid ingredientId, CancellationToken cancellationToken);

    Task RemoveIngredientFromDessert(Guid dessertId, Guid ingredientId, CancellationToken cancellationToken);

    Task<List<Ingredient>> GetIngredientForDrink(Guid drinkId, CancellationToken token);
}
