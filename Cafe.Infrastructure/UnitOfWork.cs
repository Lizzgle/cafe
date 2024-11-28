using Cafe.Domain.Abstractions;
using Cafe.Infrastructure.Repositories;

namespace Cafe.Infrastructure;

internal class UnitOfWork : IUnitOfWork
{
    private readonly string _connectionString;

    private IUserRepository? _users;

    public UnitOfWork(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IUserRepository UserRepository => _users ??= new UserRepository(_connectionString);
}
