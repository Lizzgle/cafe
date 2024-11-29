using Cafe.Domain.Entities;
using System.Data;

namespace Cafe.Domain.Abstractions;

public interface IBaseRepository<T> where T : Base
{
    Task CreateAsync(T entity, CancellationToken token = default);

    Task UpdateAsync(T entity, CancellationToken token = default);

    Task DeleteAsync(T entity, CancellationToken token = default);

    Task<List<T>> GetAllAsync(CancellationToken token = default);

    Task<T?> GetByIdAsync(Guid id, CancellationToken token = default);

    string TableName { get; }

    T MapToEntity(IDataReader reader);
}
