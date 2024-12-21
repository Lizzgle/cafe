namespace Cafe.Domain.Entities;

public class FAQ
{
    public static FAQ Dogfriendly => new(1, "Можно ли придти с собакой в кафе?", "Да, можно наше заведение dogfriendly.");

    public static FAQ WorkingTime => new(2, "Какое время работы вашего заведение", "Мы открыты с 10:00 до 22:00.");

    public static FAQ Milk => new(3, "Есть ли альтернативное молоко?", "Да, у нас есть кокосовое, миндальное и пшеничное.");

    public static FAQ Event => new(4, "Можно ли у вас провести мероприятие?", "Да, вы можете заранее оповестить и забронировать кафе на проведение мероприятия.");

    public static FAQ Laptop => new(5, "Можно ли придти к вам с ноутбуком?", "Да, вы можете купить в нашем заведении любой напиток или дессерт и сидеть в ноутбуке.");

    public static FAQ Work => new(6, "Как устроиться к вам работать", "Вы можете обратиться по номеру телефона или подойти к сотрудникам нашего заведение.");

    public int Id { get; set; }

    public string Question { get; set; }

    public string Answer { get; set; }

    protected FAQ(int id, string question, string answer)
    {
        Id = id;
        Question = question;
        Answer = answer;
    }

    public static explicit operator FAQ(int id) => FromId(id);

    public static FAQ? FromId(int id)
    {
        return id switch
        {
            1 => Dogfriendly,
            2 => WorkingTime,
            3 => Milk,
            4 => Event,
            5 => Laptop,
            6 => Work,
            _ => null
        };
    }
}
