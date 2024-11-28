namespace Cafe.Domain.Entities;

public class Category
{
    public static Category Coffee => new(1, "cofee");

    public static Category Tea => new(2, "tea");

    public static Category Milkshake => new(3, "milkshake");

    public static Category Coctail => new(4, "coctail");

    public static Category Alcohol => new(5, "alcohol");

    public static Category Other => new(6, "other");

    public int Id { get; set; }
    public string Name { get; set; }

    protected Category(int id, string name)
    {
        Id = id;
        Name = name.ToLower();
    }

    public override string ToString() => Name;

    public static explicit operator int(Category category) => category.Id;
}
