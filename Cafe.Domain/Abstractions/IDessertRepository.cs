using Cafe.Domain.Entities;

namespace Cafe.Domain.Abstractions;

public interface IDessertRepository : IBaseRepository<Dessert>
{
    Task<Dessert?> GetDessertByName(string name, CancellationToken token = default);
}
