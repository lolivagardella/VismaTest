using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VismaTest.API.Presenters.Interfaces;
using VismaTest.Application.Mediators.UserOperations.Create;
using VismaTest.Domain.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VismaTest.API.Controllers.V1
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        public RolesController(IMediator mediator, IRolePresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        private readonly IMediator _mediator;
        private readonly IRolePresenter _presenter;

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoleDto rol)
        {
            try
            {
                var rolrequest = new AddRoleRequest(rol);
                var result = await _mediator.Send(rolrequest);
                return _presenter.GetSingleRol(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
