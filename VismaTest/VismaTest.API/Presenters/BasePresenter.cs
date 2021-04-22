﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using VismaTest.API.Model;
using VismaTest.API.Presenters.Interfaces;
using VismaTest.Application.Notifications;

namespace VismaTest.API.Presenters
{
    [ExcludeFromCodeCoverage]
    public class BasePresenter : IBasePresenter
    {
        public virtual IActionResult GetActionResult<T>(T result)
            where T : Result
        {
            if (result.Invalid)
            {
                return CreateErrorResult(result);
            }

            return new OkResult();
        }

        public virtual IActionResult GetActionResult<T, Y>(T result)
            where Y : class
            where T : EntityResult<Y>
        {
            if (result.Error != null)
            {
                return CreateErrorResult(result);
            }

            var res = new JsonResult(result.Entity)
            {
                StatusCode = 200
            };
            return res;

        }

        protected virtual IActionResult CreateErrorResult<T>(T result)
            where T : Result
        {
            var errorBody = ApiError.FromResult(result);
            switch (result.Error)
            {
                case ErrorCode.NotFound: return new NotFoundObjectResult(errorBody);
                case ErrorCode.Business: return new UnprocessableEntityObjectResult(errorBody);
                case ErrorCode.Unauthorized: return new UnauthorizedObjectResult(errorBody);
                case ErrorCode.BadRequest:
                default: return new BadRequestObjectResult(errorBody);
            }
        }

    }
}
