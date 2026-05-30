using Microsoft.AspNetCore.Mvc.Filters;

namespace Empleado.Api.Filter;

public class GlobalActionLoggingFilter : IAsyncActionFilter
{
    private readonly ILogger<GlobalActionLoggingFilter> _logger;

    public GlobalActionLoggingFilter(ILogger<GlobalActionLoggingFilter> logger)
    {
        _logger = logger;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        _logger.LogInformation("Executing action: {ActionName}", context.ActionDescriptor.DisplayName);
        await next();
        _logger.LogInformation("Executed action: {ActionName}", context.ActionDescriptor.DisplayName);
    }
}
