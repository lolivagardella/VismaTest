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
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, EntityResult<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            ILogger<CreateUserHandler> logger,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<EntityResult<UserDto>> Handle(CreateUserRequest request, System.Threading.CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Creacion-Pedido - PedidoId[{request.User.Id}]", request.User);
            try
            {
                if (request.Invalid)
                {
                    return new EntityResult<UserDto>(request.Notifications, new UserDto()) { Error = ErrorCode.BadRequest };
                }
                var exists = _userRepository.GetByEmail(request.User.Email);
                if (exists == null)
                {
                    var user = _mapper.Map<User>(request.User);
                    user.Id = Guid.NewGuid();
                    var resultado = await _userRepository.InsertAsync(user);
                    var userdto = _mapper.Map<UserDto>(resultado);
                    _unitOfWork.SaveSync();
                    return new EntityResult<UserDto>(request.Notifications, userdto);
                }
                request.AddNotification(new Notification("UserOperation-AddUserHandler", "The user already exists"));
                return new EntityResult<UserDto>(request.Notifications, null);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("PedidoOperation-CreatePedidoHandler", ex);
                request.AddNotification(new Notification("PedidoOperation-CreatePedidoHandler", $"Internal Server Error: {ex.Message}"));
                throw;
            }
            finally
            {
                _logger.LogInformation("Create Pedido process finished");
            }
        }
    }
}
