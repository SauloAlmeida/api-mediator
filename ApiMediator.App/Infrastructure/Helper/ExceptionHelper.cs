using System;

namespace ApiMediator.App.Infrastructure.Helper
{
    public static class ExceptionHelper
    {
        public static string HandleExceptionMessage(Exception exception)
        {
            return exception.InnerException != null ? exception.InnerException.Message : exception.Message;
        }
    }
}
