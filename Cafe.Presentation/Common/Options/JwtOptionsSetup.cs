﻿using Microsoft.Extensions.Options;

namespace Cafe.Presentation.Common.Options;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private readonly IConfiguration _configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        var section = _configuration.GetSection("Jwt")
                            ?? throw new KeyNotFoundException("Can't read jwt from appsettings.json");

        options.Issuer = section["Issuer"]!;
        options.Audience = section["Audience"]!;
        options.SecretKey = section["SecretKey"]!;
    }
}
