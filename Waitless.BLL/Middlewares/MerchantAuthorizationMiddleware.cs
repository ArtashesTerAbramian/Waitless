using Ardalis.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Waitless.BLL.Services.MerchantService;
using Waitless.DAL.Models;
using Waitless.DTO;

namespace Waitless.BLL.Middlewares;

public class MerchantAuthorizationMiddleware
{
    private readonly RequestDelegate _next;

    public MerchantAuthorizationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var merchantSessionService = context.RequestServices.GetService<IMerchantSessionService>();

        if (!await merchantSessionService.HasPermission(context.Request.Path))
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;

            var error = new ErrorModelDto()
            {
                Code = -1,
                Description = "Access denied"
            };
            
            await context.Response.WriteAsJsonAsync(error);

            return;
        }

        await _next(context);
    }
}