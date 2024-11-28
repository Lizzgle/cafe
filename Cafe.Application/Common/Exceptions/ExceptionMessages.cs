namespace Event.Application.Common.Exceptions;

public class ExceptionMessages
{
    public const string UserAlreadyExists = "User with this login already exists";
    public const string UserNotFound = "User not found";

    public const string InvalidDataInToken = "Invalid data in token";
    public const string RefreshTokenIsNotValid = "Refresh token is not valid";
}
