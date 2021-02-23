using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Test.EventScheduler.Services.Exceptions;

namespace Test.EventScheduler.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                if (context.Exception is ItemNotFoundException)
                {
                    context.Result = new ObjectResult(null)
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                    context.ExceptionHandled = true;
                } 
                else if (context.Exception is InvalidActionException)
                {
                    context.Result = new ObjectResult(null)
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                    };
                    context.ExceptionHandled = true;
                }
                else
                {
                    context.Result = new ObjectResult(null)
                    {
                        StatusCode = StatusCodes.Status500InternalServerError,
                    };
                    context.ExceptionHandled = true;
                }
            }
        }
    }
}
