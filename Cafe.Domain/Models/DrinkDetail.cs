namespace Cafe.Domain.Models
{
    public class DrinkDetail
    {
            public Guid DrinkId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string CategoryName { get; set; }
            public string SizesWithPrices { get; set; }
            public string Ingredients { get; set; }

    }
}
