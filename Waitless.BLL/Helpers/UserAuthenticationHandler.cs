using System.Security.Claims;
using System.Text.Encodings.Web;
using Waitless.BLL.Services.UserService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Waitless.BLL.Helpers;

public class UserAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IUserSessionService _userSessionService;

    public UserAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IUserSessionService userSessionService) : base(options, logger, encoder, clock)
    {
        _userSessionService = userSessionService;
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

        var user = await _userSessionService.GetByToken(token);

        if (user == null)
        {
            // Invalid token, so return failure
            return AuthenticateResult.Fail("Invalid token");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserName),
            new Claim(ClaimTypes.Name, user.Id.ToString())
        };

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}