using AutoMapper;
using Flunt.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using VismaTest.Application.Notifications;
using VismaTest.Domain.DTOs;
using VismaTest.Domain.Entities;
using VismaTest.Domain.Repositories;

namespace VismaTest.Application.Mediators.UserOperations.Create
{
    public class AddRoleHandler : IRequestHandler<AddRoleRequest, EntityResult<RoleDto>>
    {
        private readonly IRolRepository _rolRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public AddRoleHandler(IRolRepository rolRepository,
            IUnitOfWork unitOfWork,
            ILogger<AddRoleHandler> logger,
            IMapper mapper)
        {
            _rolRepository = rolRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<EntityResult<RoleDto>> Handle(AddRoleRequest request, System.Threading.CancellationToken cancellationToken)
        {
            _logger.LogInformation($"AddRol - RolId[{request.Employee.Id}]", request.Employee);
            try
            {
                if (request.Invalid)
                {
                    return new EntityResult<RoleDto>(request.Notifications, null) { Error = ErrorCode.BadRequest };
                }
                var entity = _mapper.Map<Role>(request.Employee);
                var resultado = await _rolRepository.InsertAsync(entity);
                var roldto = _mapper.Map<RoleDto>(resultado);
                _unitOfWork.SaveSync();
                return new EntityResult<RoleDto>(request.Notifications, roldto);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("RoleOperation-AddRolHandler", ex);
                request.AddNotification(new Notification("RoleOperation-AddRolHandler", $"Internal Server Error: {ex.Message}"));
                throw;
            }
            finally
            {
                _logger.LogInformation("Create Rol process finished");
            }
        }
    }
}
