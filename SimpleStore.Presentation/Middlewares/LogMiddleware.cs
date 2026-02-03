namespace SimpleStore.Presentation.Middleware;

public class LogMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
{
   private readonly RequestDelegate _next = next;
   private readonly ILoggerFactory _loggerFactory = loggerFactory;

    public async Task InvokeAsync(HttpContext context)
   {
        var logger = _loggerFactory.CreateLogger<LogMiddleware>();
        logger.LogInformation("{Path} at {time}", context.Request.Path, DateTime.Now);
        await _next(context);
        logger.LogInformation("{Path}: {StatusCode}", context.Request.Path, context.Response.StatusCode);
   }
}