namespace Cafe.Presentation.Common.Requests.Prices
{
    public class CreatePriceRequest
    {
        required public Guid DrinkId { get; set; }

        required public string SizeName { get; set; }

        required public float Cost { get; set; }
    }
}
