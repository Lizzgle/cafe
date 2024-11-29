namespace Cafe.Domain.Entities;

public class Feedback : Base
{
    public DateTime Date { get; set; }

    public int Rating { get; set; }

    public string Description { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public User User { get; set; }
}
