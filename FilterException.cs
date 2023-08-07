using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace API;

public class FilterException : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        ObjectResult responseMessage;

        switch (context.Exception)
        {
            case System.ArgumentException:
                responseMessage = CreateResponseMessage(context, HttpStatusCode.BadRequest, context.Exception.Message);
                break;

            case System.Data.DuplicateNameException:

                responseMessage = CreateResponseMessage(context, HttpStatusCode.BadRequest, context.Exception.Message);
                break;

            case System.UnauthorizedAccessException:

                responseMessage = CreateResponseMessage(context, HttpStatusCode.Unauthorized, context.Exception.Message);
                break;

            case System.ComponentModel.DataAnnotations.ValidationException:
                responseMessage = CreateResponseMessage(context, HttpStatusCode.BadRequest, context.Exception.Message);
                break;

            case System.NullReferenceException:
                responseMessage = CreateResponseMessage(context, HttpStatusCode.BadRequest, context.Exception.Message);
                break;

            case System.NotImplementedException:
                responseMessage = CreateResponseMessage(context, HttpStatusCode.NotImplemented, context.Exception.Message);
                break;
            case HttpRequestException:
                responseMessage = CreateResponseMessage(context, HttpStatusCode.BadRequest, context.Exception.Message);
                break;
            default:
                responseMessage = CreateResponseMessage(context, HttpStatusCode.InternalServerError, context.Exception.Message);
                break;
        }

        context.Result = responseMessage;
    }

    private ObjectResult CreateResponseMessage(ExceptionContext context, HttpStatusCode statusCode, string message)
    {
        var result = new ObjectResult(new
        {
            message,
            ExceptionType = context.Exception.GetType().FullName,
        })
        {
            StatusCode = Convert.ToInt32(statusCode)
        };

        return result;
    }
}
