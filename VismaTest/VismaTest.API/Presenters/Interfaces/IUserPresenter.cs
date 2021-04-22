using Microsoft.AspNetCore.Mvc;
using VismaTest.Application.Notifications;
using VismaTest.Domain.DTOs;

namespace VismaTest.API.Presenters.Interfaces
{
    public interface IUserPresenter
    {
        IActionResult GetInsertResult(UserDto result);
        IActionResult GetSingleUser(EntityResult<UserDto> result);
        IActionResult DeleteUserResult(Result result);
        IActionResult UpdateUserResult(Result result);
    }
}