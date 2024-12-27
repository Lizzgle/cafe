using Cafe.Domain.Entities;
using Cafe.Domain.Models;

namespace Cafe.Domain.Abstractions;

public interface IDrinkRepository : IBaseRepository<Drink>
{
    Task<Drink?> GetDrinkByName(string name, CancellationToken token = default);

    List<DrinkDetail> GetDrinkDetails();
}
