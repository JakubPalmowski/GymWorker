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
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public CreateExerciseCommandHandler(IMapper mapper, IExerciseRepository exerciseRepository, IUserService userService)
        {
            _mapper = mapper;
            _exerciseRepository = exerciseRepository;
            _userService = userService;
        }
        public async Task<ExerciseNameResponse> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            if (!await _userService.CheckIfUserExists(request.IdTrainer, cancellationToken))
                throw new NotFoundException("User not found");

            if (!(await _userService.CheckIfUserIsTrainer(request.IdTrainer, cancellationToken) || await _userService.CheckIfUserIsDieticianTrainer(request.IdTrainer, cancellationToken)))
                throw new BadRequestException("User is not a trainer");

            var exercise = _mapper.Map<Domain.Entities.Exercise>(request);
            await _exerciseRepository.CreateExerciseAsync(exercise, cancellationToken);
            return _mapper.Map<ExerciseNameResponse>(exercise);
        }

    }
}