using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Queries.Admin.GetUserInfoForVerification;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetUserInfoForVeryfication
{
    public class GetUserInfoForVerificationQueryHandler : IRequestHandler<GetUserInfoForVerificationQuery, GetUserInfoForVerificationQuery>
    {
        private readonly IRepository<Domain.Entities.User> _userBaseRepository;
        private readonly IMapper _mapper;

        public GetUserInfoForVerificationQueryHandler(IRepository<Domain.Entities.User> userBaseRepository, IMapper mapper)
        {
            _userBaseRepository = userBaseRepository;
            _mapper = mapper;
        }
        public async Task<GetUserInfoForVerificationQuery> Handle(GetUserInfoForVerificationQuery request, CancellationToken cancellationToken)
        {
            var user = await _userBaseRepository.GetByIdAsync(request.IdUser, cancellationToken);
            if (user == null)
                throw new NotFoundException("User not found");
            
            var userDto = _mapper.Map<GetUserInfoForVerificationQuery>(user);
            return userDto;
        }
    }
}
