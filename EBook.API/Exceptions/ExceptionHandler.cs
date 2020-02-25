namespace EBook.API.Exceptions
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Newtonsoft.Json;

    public class ExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            // @TODO:
            // - Add custom exception handlers

            var result = JsonConvert.SerializeObject(new { context.HttpContext.Response.StatusCode, Error = exception.Message });

            context.Result = new ObjectResult(result);
        }
    }
}
