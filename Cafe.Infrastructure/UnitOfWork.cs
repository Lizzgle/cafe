using Cafe.Domain.Abstractions;
using Cafe.Infrastructure.Repositories;

namespace Cafe.Infrastructure;

internal class UnitOfWork : IUnitOfWork
{
    private readonly string _connectionString;

    private IUserRepository? _users;

    private IFeedbackRepository _feedbacks;

    public UnitOfWork(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IUserRepository UserRepository => _users ??= new UserRepository(_connectionString);

    public IFeedbackRepository FeedbackRepository => _feedbacks ??= new FeedbackRepository(_connectionString);
}
