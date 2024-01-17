using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.CQRS.Responses.Trainer;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.User.Trainer.GetById
{
    public class GetTrainerPersonalInfoQueryHandler : IRequestHandler<GetTrainerPersonalInfoQuery, TrainerPersonalInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.User> _repository;
        private readonly IUserService _userService;

        public GetTrainerPersonalInfoQueryHandler(IMapper mapper, IRepository<Domain.Entities.User> repository, IUserService userService)
        {
            _mapper = mapper;
            _repository = repository;
            _userService = userService;
        }
        public async Task<TrainerPersonalInfoResponse> Handle(GetTrainerPersonalInfoQuery request, CancellationToken cancellationToken)
        {
            var trainer = await _repository.GetUserWithDetailsAsync(request.id, cancellationToken);
            if (trainer == null)
                throw new NotFoundException("Trainer not found");
            var role = await _userService.CheckIfUserIsTrainer(request.id, cancellationToken);
            if (!role)
                throw new BadRequestException("User is not a trainer");

            var trainerResponse = _mapper.Map<TrainerPersonalInfoResponse>(trainer);
            return trainerResponse;
        }

    }
}
