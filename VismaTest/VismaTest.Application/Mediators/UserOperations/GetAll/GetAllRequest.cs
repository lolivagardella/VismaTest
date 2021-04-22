using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;
using VismaTest.Application.Notifications;
using VismaTest.Domain.DTOs;

namespace VismaTest.Application.Mediators.UserOperations.GetAll
{
    public class GetAllRequest : Notifiable, IRequest<EntityResult<List<UserDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetAllRequest(int? pageNumber, int? pageSize)
        {
            PageNumber = pageNumber ?? 1;
            PageSize = pageSize ?? 10;
        }
    }
}
