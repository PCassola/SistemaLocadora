using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using ProvaTeste.Services;
using System;

namespace ProvaTeste.Filters
{
    public class AuthorizationActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            StringValues headerValue = "";

            context.HttpContext.Request.Headers.TryGetValue("Authorization", out headerValue);

            headerValue = string.IsNullOrEmpty(headerValue) ? "" : headerValue;

            var smToken = JwtServices.DecodeJson(headerValue);

            if (smToken == null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Token Expirado."
                };
            }
        }
    }
}
