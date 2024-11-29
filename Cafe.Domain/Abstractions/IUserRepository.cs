using Cafe.Domain.Entities;

namespace Cafe.Domain.Abstractions;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetUserByLogin(string login, CancellationToken token = default);

    Task<User?> GetUserByLoginAndPassword(string login, string password, CancellationToken token = default);

    Task AddRoleToUserAsync(User user, Role role, CancellationToken token = default);
}
