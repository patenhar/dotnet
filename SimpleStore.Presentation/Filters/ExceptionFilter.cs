using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SimpleStore.Presentation.Utils;

namespace SimpleStore.Presentation.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var error = new CustomError(500, context.Exception.Message, context.Exception.StackTrace?.ToString());
        context.Result = new JsonResult(error);
    }
}

