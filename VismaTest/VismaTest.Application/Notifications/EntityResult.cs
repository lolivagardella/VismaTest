using Flunt.Notifications;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace VismaTest.Application.Notifications
{
    [ExcludeFromCodeCoverage]
    public class EntityResult<T> : Result where T : class
    {
        public EntityResult(IReadOnlyCollection<Notification> notifications, T entity)
            : base(notifications)
        {
            Entity = entity;
        }

        public T Entity { get; }
    }
}
