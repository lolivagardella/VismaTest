using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.CodeAnalysis;
using VismaTest.API.Presenters.Interfaces;
using VismaTest.Application.Notifications;
using VismaTest.Domain.DTOs;
using VismaTest.Domain.Helpers;

namespace VismaTest.API.Presenters
{
    [ExcludeFromCodeCoverage]
    public class UserPresenter : BasePresenter, IUserPresenter
    {
        private readonly IMapper _mapper;
        public UserPresenter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult GetAllPedidoResult(EntityResult<PagedResult<UserDto>> result)
        {
            if (result.Valid)
            {
                return new OkObjectResult(result);
            }
            else
            {
                switch (result.Error)
                {
                    case ErrorCode.BadRequest:
                        return new BadRequestObjectResult(result.Notifications);

                    case ErrorCode.InternalServerError:
                        return new ObjectResult(result.Notifications) { StatusCode = StatusCodes.Status500InternalServerError };

                    case ErrorCode.NotFound:
                        return new NotFoundObjectResult(result.Notifications);

                    case ErrorCode.Unauthorized:
                        return new UnauthorizedObjectResult(result.Notifications);

                    default:
                        break;
                }
                throw new NotImplementedException();
            }
        }

        public IActionResult GetInsertResult(UserDto result)
        {
            if (result != null)
            {
                return new CreatedResult("", result);
            }
            return new NotFoundResult();
        }

        public IActionResult GetSinglePedido(EntityResult<UserDto> result)
        {
            return GetInsertResult(result.Entity);
        }

        public IActionResult DeletePedidoResult(Result result)
        {
            return result.Invalid ? base.GetActionResult(result) : new OkObjectResult(result);
        }

        public IActionResult UpdatePedidoResult(Result result)
        {
            return result.Invalid ? base.GetActionResult(result) : new NoContentResult();
        }


        public IActionResult GetSingleUser(EntityResult<UserDto> result)
        {
            return GetInsertResult(result.Entity);
        }

        public IActionResult DeleteUserResult(Result result)
        {
            throw new NotImplementedException();
        }

        public IActionResult UpdateUserResult(Result result)
        {
            throw new NotImplementedException();
        }


    }
}