using Flunt.Notifications;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace VismaTest.Application.Notifications
{
    [ExcludeFromCodeCoverage]
    public class Result : Notifiable
    {
        public Result(IReadOnlyCollection<Notification> notifications)
        {
            AddNotifications(notifications);
        }

        public void AddNotification(string error)
        {
            AddNotification(null, error);
        }

        public void AddNotification(string error, ErrorCode errorCode)
        {
            AddNotification(null, error);
            Error = errorCode;
        }

        public void AddNotification(string property, string message, ErrorCode errorCode)
        {
            AddNotification(property, message);
            Error = errorCode;
        }

        public void AddNotification(Notification notification, ErrorCode errorCode)
        {
            AddNotification(notification);
            Error = errorCode;
        }
        public void AddNotifications(IReadOnlyCollection<Notification> notifications, ErrorCode errorCode)
        {
            AddNotifications(notifications);
            Error = errorCode;
        }

        public ErrorCode? Error { get; set; }



    }
}
