namespace Cafe.Domain.Abstractions;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
}
