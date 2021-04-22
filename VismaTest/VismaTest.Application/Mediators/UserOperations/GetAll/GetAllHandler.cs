using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VismaTest.Application.Notifications;
using VismaTest.Domain.DTOs;
using VismaTest.Domain.Repositories;

namespace VismaTest.Application.Mediators.UserOperations.GetAll
{
    public class GetAllHandler : IRequestHandler<GetAllRequest, EntityResult<List<UserDto>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllHandler(IUserRepository pedidoRepository,
            IMapper mapper)
        {
            _userRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<EntityResult<List<UserDto>>> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var users = _userRepository.GetAll();
                var result = _mapper.Map<List<UserDto>>(users);
                return new EntityResult<List<UserDto>>(request.Notifications, result);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
