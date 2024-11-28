namespace Cafe.Presentation.Common.Options
{
    public class JwtOptions
    {
        required public string Issuer { get; set; }

        required public string Audience { get; set; }

        required public string SecretKey { get; set; }
    }
}
