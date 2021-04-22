using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace VismaTest.Application.Notifications
{
    [ExcludeFromCodeCoverage]
    public static class ErrorCodeMapper
    {
        public static ErrorCode MapperErrorCode(HttpStatusCode httpStatusCode) =>
                httpStatusCode switch
                {
                    HttpStatusCode.NotFound => ErrorCode.NotFound,
                    HttpStatusCode.BadRequest => ErrorCode.BadRequest,
                    HttpStatusCode.UnprocessableEntity => ErrorCode.Business,
                    HttpStatusCode.Unauthorized => ErrorCode.Unauthorized,
                    _ => ErrorCode.InternalServerError
                };
    }
}