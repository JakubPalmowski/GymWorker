using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.User.DieticianTrainer.GetById
{
    public class GetDieticianTrainerPersonalInfoQueryHandler : IRequestHandler<GetDieticianTrainerPersonalInfoQuery, DieticianTrainerPersonalInfoResponse>
    {
        private readonly IRepository<Domain.Entities.User> _repository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public GetDieticianTrainerPersonalInfoQueryHandler(IRepository<Domain.Entities.User> repository, IMapper mapper, IUserService userService)
        {
            _repository = repository;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<DieticianTrainerPersonalInfoResponse> Handle(GetDieticianTrainerPersonalInfoQuery request, CancellationToken cancellationToken)
        {
            var dieticianTrainer = await _repository.GetByIdAsync(request.id, cancellationToken);
            if (dieticianTrainer == null)
                throw new NotFoundException("User not found");
            var role = await _userService.CheckIfUserIsDieticianTrainer(request.id, cancellationToken);
            if (!role)
                throw new BadRequestException("User is not a dietician-trainer");

            var dieticianTrainerResponse = _mapper.Map<DieticianTrainerPersonalInfoResponse>(dieticianTrainer);
            return dieticianTrainerResponse;
        }
    }
}
