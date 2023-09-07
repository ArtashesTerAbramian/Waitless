using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Waitless.BLL.Services.MerchantService;

namespace Waitless.BLL.Helpers;

public class MerchantAuthenticationHelper : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IMerchantSessionService _merchantSessionService;

    public MerchantAuthenticationHelper(IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        IMerchantSessionService merchantSessionService,
        ISystemClock clock) : base(options, logger, encoder, clock)
    {
        _merchantSessionService = merchantSessionService;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue("Authorization", out var authorizationHeaderValues))
        {
            // No Authorization header present, so return failure
            return AuthenticateResult.NoResult();
        }

        string token = authorizationHeaderValues.FirstOrDefault();

        if (string.IsNullOrEmpty(token))
        {
            // Token is missing, so return failure
            return AuthenticateResult.NoResult();
        }

        var user = await _merchantSessionService.GetByToken(token);

        if (user is null)
        {
            // Invalid token, so return failure
            return AuthenticateResult.Fail("Invalid token");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Id.ToString())
        };

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}