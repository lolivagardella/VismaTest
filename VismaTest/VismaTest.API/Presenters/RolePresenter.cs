using Microsoft.AspNetCore.Mvc;
using VismaTest.API.Presenters.Interfaces;
using VismaTest.Application.Notifications;
using VismaTest.Domain.DTOs;

namespace VismaTest.API.Presenters
{
    public class RolePresenter : BasePresenter, IRolePresenter
    {
        public RolePresenter()
        {
        }

        public IActionResult GetInsertResult(RoleDto result)
        {
            if (result != null)
            {
                return new CreatedResult("", result);
            }
            return new NotFoundResult();
        }

        public IActionResult GetSingleRol(EntityResult<RoleDto> result)
        {
            return GetInsertResult(result.Entity);
        }

        public IActionResult GetSingleRoles(EntityResult<RoleDto> result)
        {
            return GetInsertResult(result.Entity);
        }

    }
}