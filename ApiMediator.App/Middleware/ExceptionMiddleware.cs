using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace ApiMediator.App.Middleware
{
    public class ExceptionMiddleware : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Exception exception = context.Exception;

            if (exception.Message == Infrastructure.Constant.Exception.TASK_CANCELED) return;

            var exceptionMessage = exception.InnerException != null ? exception.Message + " " + exception.InnerException.Message : exception.Message;

            context.Result = new JsonResult(exceptionMessage);

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
    }
}
