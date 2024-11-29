using Cafe.Domain.Entities;

namespace Cafe.Domain.Abstractions;

public interface IFeedbackRepository
{
    Task CreateFeedbackAsync(Feedback feedback, CancellationToken token = default);

    Task DeleteFeedbackAsync(Feedback feedback, CancellationToken token = default);

    Task<List<Feedback>> GetAllFeedbacksAsync(CancellationToken token = default);

    Task<Feedback?> GetFeedbackByIdAsync(Guid id, CancellationToken token = default);
}
