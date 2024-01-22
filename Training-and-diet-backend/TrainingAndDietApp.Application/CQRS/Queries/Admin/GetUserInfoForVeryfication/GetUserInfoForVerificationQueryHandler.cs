using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Admin.GetUserInfoForVerification
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
            //sprawdzic jescze czy user jest mentorem???
            var user = await _userBaseRepository.GetByIdAsync(request.IdUser, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            var userDto = _mapper.Map<GetUserInfoForVerificationQuery>(user);
            return userDto;
        }
    }
}
