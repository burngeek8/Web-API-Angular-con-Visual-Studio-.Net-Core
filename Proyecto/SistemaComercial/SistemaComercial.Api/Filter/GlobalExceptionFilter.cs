using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SistemaComercial.Api.Filter;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ValidationException validationException)
        {
            var validationResponse = new ValidationProblemDetails(
                validationException.Errors
                    .GroupBy(error => error.PropertyName)
                    .ToDictionary(
                        group => group.Key,
                        group => group.Select(error => error.ErrorMessage).ToArray()))
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Error de validacion."
            };

            context.Result = new BadRequestObjectResult(validationResponse);
            context.ExceptionHandled = true;
            return;
        }

        var response = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Ocurrio un error inesperado.",
            Detail = context.Exception.Message
        };

        context.Result = new ObjectResult(response)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };

        context.ExceptionHandled = true;
    }
}
