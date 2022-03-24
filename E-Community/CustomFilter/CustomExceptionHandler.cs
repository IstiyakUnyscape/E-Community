using CustomModel;
using ERROR_HANDLING;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace E_Community.CustomFilter
{
    public class CustomExceptionHandler : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode statusCode = (context.Exception as WebException != null &&
                        ((HttpWebResponse)(context.Exception as WebException).Response) != null) ?
                         ((HttpWebResponse)(context.Exception as WebException).Response).StatusCode
                         : getErrorCode(context.Exception.GetType());
            string errorMessage = context.Exception.Message;
            string innerMessage = String.Empty;// context.Exception.InnerException.Message;
            string stackTrace = context.Exception.StackTrace;
            string path = context.ActionDescriptor.DisplayName;


            try
            {
                errorMessage = context.Exception.Message;
            }
            catch (Exception E)
            {
                innerMessage = "CustomExceptionHandler (Line 30): " + E.ToString();
            }
            try
            {
                innerMessage = context.Exception.InnerException.Message;
            }
            catch (Exception E)
            {
                innerMessage = "CustomExceptionHandler (Line 38): " + E.ToString();
            }
            try
            {
                stackTrace = context.Exception.StackTrace;
            }
            catch (Exception E)
            {
                innerMessage = "CustomExceptionHandler (Line 46): " + E.ToString();
            }
            try
            {
                path = context.ActionDescriptor.DisplayName;
            }
            catch (Exception E)
            {
                innerMessage = "CustomExceptionHandler (Line 54): " + E.ToString();
            }

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)statusCode;
            response.ContentType = "application/json";

            #region Logging  

            Singleton _errorLog = Singleton.getInstance;
            ErrorEntitesModel _errorEntite = new ErrorEntitesModel
            {

                errorCode = (int)statusCode,
                errorType = "",
                innerMessage = innerMessage,
                message = errorMessage,
                path = path


            };
            _errorLog.logExpection(_errorEntite);
            #endregion Logging  

        }
        private HttpStatusCode getErrorCode(Type exceptionType)
        {
            ExceptionsEnum tryParseResult;
            if (Enum.TryParse<ExceptionsEnum>(exceptionType.Name, out tryParseResult))
            {
                switch (tryParseResult)
                {
                    case ExceptionsEnum.NullReferenceException:
                        return HttpStatusCode.LengthRequired;

                    case ExceptionsEnum.FileNotFoundException:
                        return HttpStatusCode.NotFound;

                    case ExceptionsEnum.OverflowException:
                        return HttpStatusCode.RequestedRangeNotSatisfiable;

                    case ExceptionsEnum.OutOfMemoryException:
                        return HttpStatusCode.ExpectationFailed;

                    case ExceptionsEnum.InvalidCastException:
                        return HttpStatusCode.PreconditionFailed;

                    case ExceptionsEnum.ObjectDisposedException:
                        return HttpStatusCode.Gone;

                    case ExceptionsEnum.UnauthorizedAccessException:
                        return HttpStatusCode.Unauthorized;

                    case ExceptionsEnum.NotImplementedException:
                        return HttpStatusCode.NotImplemented;

                    case ExceptionsEnum.NotSupportedException:
                        return HttpStatusCode.NotAcceptable;

                    case ExceptionsEnum.InvalidOperationException:
                        return HttpStatusCode.MethodNotAllowed;

                    case ExceptionsEnum.TimeoutException:
                        return HttpStatusCode.RequestTimeout;

                    case ExceptionsEnum.ArgumentException:
                        return HttpStatusCode.BadRequest;

                    case ExceptionsEnum.StackOverflowException:
                        return HttpStatusCode.RequestedRangeNotSatisfiable;

                    case ExceptionsEnum.FormatException:
                        return HttpStatusCode.UnsupportedMediaType;

                    case ExceptionsEnum.IOException:
                        return HttpStatusCode.NotFound;

                    case ExceptionsEnum.IndexOutOfRangeException:
                        return HttpStatusCode.ExpectationFailed;

                    default:
                        return HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}
