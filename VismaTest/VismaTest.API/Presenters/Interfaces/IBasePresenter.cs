using Microsoft.AspNetCore.Mvc;
using VismaTest.Application.Notifications;

namespace VismaTest.API.Presenters.Interfaces
{
    public interface IBasePresenter
    {
        IActionResult GetActionResult<T, Y>(T result)
            where T : EntityResult<Y>
            where Y : class;
        IActionResult GetActionResult<T>(T result) where T : Result;
    }
}