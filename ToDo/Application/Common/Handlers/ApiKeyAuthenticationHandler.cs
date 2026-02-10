using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using ToDo.Application.Common.Options;

namespace ToDo.Application.Common.Handlers;

public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IOptionsMonitor<ApiOptions> _apiOptions;
    public const string SchemeName = "ApiKey";

    public ApiKeyAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        IOptionsMonitor<ApiOptions> apiOptions,
        ILoggerFactory loggerFactory,
        UrlEncoder urlEncoder) : base(options, loggerFactory, urlEncoder)
    {
        _apiOptions = apiOptions;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if(!Request.Headers.TryGetValue("api-key", out var apiKeyHandlerValue))
        {
            return Task.FromResult(AuthenticateResult.Fail(
                "The API key is missing from header"));
        }

        if(apiKeyHandlerValue != _apiOptions.CurrentValue.Key)
        {
            return Task.FromResult(AuthenticateResult.Fail(
                "The API key does not mach the config"));
        }

        var identity = new ClaimsIdentity(
            [new Claim(ClaimTypes.Name, SchemeName)],
            SchemeName);

        return Task.FromResult(AuthenticateResult.Success(
            new AuthenticationTicket(
                new ClaimsPrincipal(identity),
                SchemeName)));
    }
}
