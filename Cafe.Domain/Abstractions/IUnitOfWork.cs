namespace Cafe.Domain.Abstractions;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }

    IFeedbackRepository FeedbackRepository { get; }

    IDessertRepository DessertRepository { get; }
}
