using Cafe.Domain.Entities;

namespace Cafe.Domain.Abstractions;

public interface IPriceRepository : IBaseRepository<Price>
{
    Task<List<Price>> GetPricesForDrink(Guid drinkId, CancellationToken token);

    Task<Price?> GetPriceForDrinkAndSize(Guid drinkId, int sizeId, CancellationToken token);
}
