using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.CQRS.Responses.Dietician;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.User.Dietician.GetById
{
    public class GetDieticianPersonalInfoQueryHandler : IRequestHandler<GetDieticianPersonalInfoQuery, DieticianPersonalInfoResponse>
    {
        private readonly IRepository<Domain.Entities.User> _repository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public GetDieticianPersonalInfoQueryHandler(IRepository<Domain.Entities.User> repository, IMapper mapper, IUserService userService)
        {
            _repository = repository;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<DieticianPersonalInfoResponse> Handle(GetDieticianPersonalInfoQuery request, CancellationToken cancellationToken)
        {
            var dietician = await _repository.GetByIdAsync(request.id, cancellationToken);
            if (dietician == null)
                throw new NotFoundException("Dietician not found");
            var role = await _userService.CheckIfUserIsDietician(request.id, cancellationToken);
            if (!role)
                throw new BadRequestException("User is not a pupil");

            var dietcianResponse = _mapper.Map<DieticianPersonalInfoResponse>(dietician);
            return dietcianResponse;
        }
    }
}
