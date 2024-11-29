namespace Cafe.Presentation.Common.Requests.Feedbacks;

public class CreateFeedbackRequest
{
    required public int Rating { get; set; }

    public string? Description { get; set; }
}
