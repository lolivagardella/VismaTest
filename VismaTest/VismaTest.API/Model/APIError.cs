using Flunt.Notifications;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using VismaTest.Application.Notifications;

namespace VismaTest.API.Model
{
    [ExcludeFromCodeCoverage]
    public class ApiError
    {
        public ApiError()
        {
        }

        public ApiError(IEnumerable<Notification> errors, ErrorCode? error = null)
        {
            ErrorType = error;
            Errors = errors;
        }

        public ErrorCode? ErrorType { get; private set; }
        public IEnumerable<Notification> Errors { get; private set; }

        public static ApiError FromResult(Result result)
        {
            return new ApiError(result.Notifications, result.Error);
        }
    }
}
