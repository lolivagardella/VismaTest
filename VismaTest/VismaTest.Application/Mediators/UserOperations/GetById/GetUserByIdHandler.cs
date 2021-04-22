using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VismaTest.Application.Notifications;
using VismaTest.Domain.DTOs;
using VismaTest.Domain.Repositories;

namespace VismaTest.Application.Mediators.UserOperations.GetById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, EntityResult<UserDto>>
    {
        public GetUserByIdHandler(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IUserRepository _userRepository { get; }
        private readonly IMapper _mapper;

        public async Task<EntityResult<UserDto>> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.Valid)
            {
                var result = await _userRepository.GetById(request.UserId);
                if (result != null)
                {

                    var userdto = new UserDto()
                    {
                        Id = result.Id,
                        Department = result.Department,
                        Name = result.Name,
                        Password = result.Password,
                    };
                    return new EntityResult<UserDto>(request.Notifications, userdto);
                }
                else
                {
                    request.AddNotification("Pedido", "No se encontro el pedido");
                    return new EntityResult<UserDto>(request.Notifications, null) { Error = ErrorCode.NotFound };
                }
            }
            else return new EntityResult<UserDto>(request.Notifications, null) { Error = ErrorCode.BadRequest };
        }
    }
}