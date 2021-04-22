using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using VismaTest.Application.Notifications;
using VismaTest.Domain.DTOs;

namespace VismaTest.Application.Mediators.UserOperations.Create
{
    public class CreateUserRequest : Notifiable, IRequest<EntityResult<UserDto>>
    {
        public UserDto User { get; }
        public CreateUserRequest(UserDto user)
        {
            User = user;
            AddNotifications(new Contract()
                .IsNotNull(User, "User", "User must not be null")
                .IsNotNull(User?.Name, "Name", "User Name is invalid")
                .IsNotNull(User?.Password, "Password", "The password is invalid"));
        }
    }
}
