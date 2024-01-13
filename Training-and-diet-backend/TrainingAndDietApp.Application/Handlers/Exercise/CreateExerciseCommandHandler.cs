using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Commands.Exercise;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Responses.Exercise;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Exercise
{
    public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, ExerciseNameResponse>
    {
        private readonly IRepository<Domain.Entities.Exercise> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public CreateExerciseCommandHandler(IMapper mapper, IRepository<Domain.Entities.Exercise> repository, IUserService userService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }
        public async Task<ExerciseNameResponse> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            if (!await _userService.CheckIfUserExists(request.IdTrainer, cancellationToken))
                throw new NotFoundException("User not found");

            if (!(await _userService.CheckIfUserIsTrainer(request.IdTrainer, cancellationToken) || await _userService.CheckIfUserIsDieticianTrainer(request.IdTrainer, cancellationToken)))
                throw new BadRequestException("User is not a trainer");

            var exercise = _mapper.Map<Domain.Entities.Exercise>(request);
            await _repository.AddAsync(exercise, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return _mapper.Map<ExerciseNameResponse>(exercise);
        }

    }
}