using Cafe.Domain.Entities;

namespace Cafe.Domain.Abstractions;

public interface IUserRepository
{
    Task CreateUserAsync(User user, CancellationToken token = default);

    Task UpdateUserAsync(User user, CancellationToken token = default);

    Task DeleteUserAsync(User user, CancellationToken token = default);

    Task<List<User>> GetAllUsersAsync(CancellationToken token = default);

    Task<User?> GetUserByIdAsync(Guid id, CancellationToken token = default);

    Task<User?> GetUserByLogin(string login, CancellationToken token = default);

    Task<User?> GetUserByLoginAndPassword(string login, string password, CancellationToken token = default);
}
