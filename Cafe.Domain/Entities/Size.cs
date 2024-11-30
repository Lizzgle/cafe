using Cafe.Domain.Entities;

namespace Cafe.Domain.Enums;

public class Size
{
    public static Size XS => new(1, "xs", 30);

    public static Size S => new(2, "s", 180);

    public static Size M => new(3, "m", 240);

    public static Size L => new(4, "l", 300);

    public int Id { get; set; }

    public string Name { get; set; }

    public int Volume { get; set; }

    public List<Price> Prices { get; set; } = new List<Price>();

    public List<Drink> Drinks { get; set; } = new List<Drink>();

    protected Size(int id, string name, int volume)
    {
        Id = id;
        Name = name.ToLower();
        Volume = volume;
    }

    public override string ToString() => $"{Name.ToUpper()} ({Volume} ml)";

    public static explicit operator int(Size size) => size.Id;

    public static explicit operator Size(int sizeId) => FromId(sizeId);

    public static Size FromId(int sizeId)
    {
        return sizeId switch
        {
            1 => XS,
            2 => S,
            3 => M,
            4 => L,
            _ => throw new NotImplementedException()
        };
    }

    public static Size? FromString(string sizeName)
    {
        sizeName = sizeName.ToLower();

        return sizeName switch
        {
            "xs" => XS,
            "s" => S,
            "m" => M,
            "l" => L,
            _ => null
        };
    }
}
