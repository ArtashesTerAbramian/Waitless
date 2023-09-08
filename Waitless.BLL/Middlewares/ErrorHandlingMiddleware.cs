using Ardalis.Result;
using Waitless.BLL.Constants;
using Waitless.BLL.Services.ErrorService;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Waitless.BLL.Middlewares;


public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context, ILogger<ErrorHandlingMiddleware> logger)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, logger);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ErrorHandlingMiddleware> logger)
    {
        context.Response.ContentType = "application/json";
        Result responseResult;

        var errorService = context.RequestServices.GetRequiredService<IErrorService>();
        if (ex is DbUpdateException dbExceptin && dbExceptin.InnerException is Npgsql.PostgresException inEx && inEx.SqlState == "23505")
        {
            //23505 unique key violates exception
            var errorMessage = (await errorService.GetById(ErrorConstants.DuplicateItem)).Description;
             responseResult = Result.Error(errorMessage);
            logger.LogError(ex, "ErrorHandlingMiddleware Db_Error");
        }

        else if (ex is DbUpdateException)
        {
            var errorMessage = (await errorService.GetById(ErrorConstants.CannotRemoveDataWithReference)).Description;
            responseResult = Result.Error(errorMessage);
            logger.LogError(ex, "ErrorHandlingMiddleware Db_Error");
        }
        else if(ex is UnauthorizedAccessException)
        {
            var errorMessage = (await errorService.GetById(ErrorConstants.Unauthorized)).Description;
            responseResult = Result.Error(errorMessage);
            logger.LogError(ex, "ErrorHandlingMiddleware Auth_Error");
        }
        else
        {
            var errorMessage = (await errorService.GetById(ErrorConstants.GeneralError)).Description;
            responseResult = Result.Error(errorMessage);
            logger.LogError(ex, "ErrorHandlingMiddleware");
        }

        context.Response.StatusCode = 500;

        var result = JsonSerializer.Serialize(responseResult, new JsonSerializerOptions()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
        });

        await context.Response.WriteAsync(result);
    }
}
