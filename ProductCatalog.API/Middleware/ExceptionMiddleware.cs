using System.Net;
using System.Text.Json;
using ProductCatalog.Domain.Exceptions;

namespace ProductCatalog.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Continua o processamento normal da requisição.
            await _next(context);
        }
        catch (DomainException ex)
        {
            // Erros causados por regras do domínio retornam HTTP 400.
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            var response = new
            {
                error = ex.Message
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response)
            );
        }
        catch (ArgumentException ex)
        {
            // Trata erros de argumentos/validação que ainda utilizam ArgumentException.
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            var response = new
            {
                error = ex.Message
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response)
            );
        }
        catch (Exception)
        {
            // Qualquer outro erro inesperado retorna HTTP 500.
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = new
            {
                error = "Ocorreu um erro interno no servidor."
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response)
            );
        }
    }
}