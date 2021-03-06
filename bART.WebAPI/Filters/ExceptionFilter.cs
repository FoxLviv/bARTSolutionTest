using bART.Services.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bART.WebAPI.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;

            string json;
            if (context.Exception.GetType().IsSerializable)
            {
                json = JsonConvert.SerializeObject(new
                {
                    errorMessage = context.Exception.Message,
                    exception = context.Exception
                }, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            else
            {
                json = JsonConvert.SerializeObject(new
                {
                    errorMessage = context.Exception.Message,
                    exception = new
                    {
                        ClassName = context.Exception.GetType().FullName,
                        context.Exception.Source,
                        context.Exception.StackTrace
                    }
                }, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }

            var result = new ContentResult { Content = json, ContentType = "application/json" };

            if (context.Exception is ItemNotFoundException)
            {
                result.StatusCode = StatusCodes.Status404NotFound;
            }
            else
            {
                result.StatusCode = StatusCodes.Status500InternalServerError;
            }

            context.Result = result;
        }
    }
}
