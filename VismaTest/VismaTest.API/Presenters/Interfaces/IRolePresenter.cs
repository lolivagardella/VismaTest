using Microsoft.AspNetCore.Mvc;
using VismaTest.Application.Notifications;
using VismaTest.Domain.DTOs;

namespace VismaTest.API.Presenters.Interfaces
{
    public interface IRolePresenter
    {
        IActionResult GetInsertResult(RoleDto result);
        IActionResult GetSingleRol(EntityResult<RoleDto> result);
    }

}