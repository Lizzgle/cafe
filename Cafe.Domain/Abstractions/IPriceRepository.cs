using Cafe.Domain.Entities;

namespace Cafe.Domain.Abstractions;

public interface IPriceRepository : IBaseRepository<Price>
{
    Task<List<Price>> GetPricesForDrink(Guid drinkId, CancellationToken token);
}
