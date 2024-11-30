namespace Cafe.Domain.Entities;

public class Category
{
    public static Category Coffee => new(1, "coffee");

    public static Category Tea => new(2, "tea");

    public static Category Milkshake => new(3, "milkshake");

    public static Category Coctail => new(4, "coctail");

    public static Category Alcohol => new(5, "alcohol");

    public static Category Other => new(6, "other");

    public int Id { get; set; }

    public string Name { get; set; }

    public virtual List<Drink> Drinks { get; set; }

    protected Category(int id, string name)
    {
        Id = id;
        Name = name.ToLower();
        Drinks = new List<Drink>();
    }

    public override string ToString() => Name;

    public static explicit operator int(Category category) => category.Id;

    public static explicit operator Category(int categoryId) => FromId(categoryId);

     public static Category? FromId(int categoryId)
    {
       
        return categoryId switch
        {
            1 => Coffee,
            2 => Tea,
            3 => Milkshake,
            4 => Coctail,
            5 => Alcohol,
            6 => Other,
            _ => null
        };
    }

    public static Category? FromString(string categoryName)
    {
        categoryName = categoryName.ToLower();

        return categoryName switch
        {
            "coffee" => Coffee,
            "tea" => Tea,
            "milkshake" => Milkshake,
            "coctail" => Coctail,
            "alcohol" => Alcohol,
            "other" => Other,
            _ => null
        };
    }
}
