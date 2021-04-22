using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using System;
using VismaTest.Application.Notifications;
using VismaTest.Domain.DTOs;

namespace VismaTest.Application.Mediators.UserOperations.GetById
{
    public class GetUserByIdRequest : Notifiable, IRequest<EntityResult<UserDto>>
    {
        public Guid UserId { get; set; }

        public GetUserByIdRequest(Guid userId)
        {
            UserId = userId;
            AddNotifications(new Contract()
                .IsNotNull(UserId, "Guid", "Guid value cannot be null"));
        }
    }
}