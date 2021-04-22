using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using VismaTest.API.Model;
using VismaTest.API.Presenters.Interfaces;
using VismaTest.Application.Mediators.UserOperations.Create;
using VismaTest.Application.Mediators.UserOperations.GetAll;
using VismaTest.Application.Mediators.UserOperations.GetById;
using VismaTest.Domain.DTOs;
using VismaTest.Domain.Helpers;

namespace VismaTest.API.Controllers.V1
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(IMediator mediator, IUserPresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        private readonly IMediator _mediator;
        private readonly IUserPresenter _presenter;

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="user">AddUserRequest</param>
        /// <response code="201">New User</response>
        /// <response code="400">Bad request</response>
        /// <response code="422">Error de negocio</response>
        [HttpPost]
        [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
        {
            try
            {
                var pedidoRequest = new CreateUserRequest(user);
                var result = await _mediator.Send(pedidoRequest);
                return _presenter.GetSingleUser(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">user id</param>
        /// <response code="200">User</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not Found</response>
        /// <response code="422">Bussiness rules violated</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var request = new GetUserByIdRequest(id);
                var result = await _mediator.Send(request);
                return null;
                //return _presenter.GetSingleUser(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtener todos los pedidos
        /// </summary>
        /// <response code="200">Prospect list</response>
        /// <response code="400">Bad request</response>
        /// <response code="422">Bussiness rules violated</response>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<UserDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> GetAll([FromHeader(Name = "X-pageNumber")] int? pageNumber,
                                            [FromHeader(Name = "X-pageSize")] int? pageSize)
        {
            try
            {
                var request = new GetAllRequest(pageNumber, pageSize);
                var result = await _mediator.Send(request);
                return null;
                //return _presenter.GetAllUserResult(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
    }
}