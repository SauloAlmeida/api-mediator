using ApiMediator.App.Infrastructure.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ApiMediator.App.Middleware
{
    public class ExceptionMiddleware : IExceptionFilter
    {
        private readonly ILogger logger;

        public ExceptionMiddleware(ILogger logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exceptionMessage = ExceptionHelper.HandleExceptionMessage(context.Exception);

            context.Result = new JsonResult(exceptionMessage);

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            logger.LogError(exceptionMessage);
        }
    }
}
