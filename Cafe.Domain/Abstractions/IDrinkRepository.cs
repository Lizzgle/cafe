using Cafe.Domain.Entities;

namespace Cafe.Domain.Abstractions;

public interface IDrinkRepository : IBaseRepository<Drink>
{
    Task<Drink?> GetDrinkByName(string name, CancellationToken token = default);
}
