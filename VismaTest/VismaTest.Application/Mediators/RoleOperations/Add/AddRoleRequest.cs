using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using VismaTest.Application.Notifications;
using VismaTest.Domain.DTOs;

namespace VismaTest.Application.Mediators.UserOperations.Create
{
    public class AddRoleRequest : Notifiable, IRequest<EntityResult<RoleDto>>
    {
        public RoleDto Employee { get; }
        public AddRoleRequest(RoleDto employee)
        {
            Employee = employee;
            AddNotifications(new Contract()
                .IsNotNull(Employee, "Employee", "Employee must not be null"));
        }
    }
}
