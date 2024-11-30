namespace Cafe.Presentation.Common.Requests.Drinks;

public class UpdateDrinkRequest
{
    required public string Name { get; set; }

    public string? Description { get; set; }
}
