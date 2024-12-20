using Cafe.Domain.Entities;

namespace Cafe.Domain.Abstractions;

public interface IFAQRepository
{
    Task<List<FAQ>> GetAllAsync(CancellationToken token = default);
}
