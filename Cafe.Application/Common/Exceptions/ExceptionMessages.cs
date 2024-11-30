namespace Event.Application.Common.Exceptions;

public class ExceptionMessages
{
    public const string UserAlreadyExists = "User with this login already exists";
    public const string DessertAlreadyExists = "Dessert with this name already exists";
    public const string DrinkAlreadyExists = "Drink with this name already exists";
    public const string PriceAlredyExists = "Price for this drink and size already exists";

    public const string UserNotFound = "User not found";
    public const string FeedbackNotFound = "Feedback not found";
    public const string DessertNotFound = "Dessert not found";
    public const string DrinkNotFound = "Drink not found";
    public const string SizeNotFound = "Size not found";
    public const string CategoryNotFound = "Category not found";
    public const string PriceNotFound = "Price not found";

    public const string UserUnauthorized = "User unauthorized";
    public const string InvalidDataInToken = "Invalid data in token";
    public const string RefreshTokenIsNotValid = "Refresh token is not valid";
}
