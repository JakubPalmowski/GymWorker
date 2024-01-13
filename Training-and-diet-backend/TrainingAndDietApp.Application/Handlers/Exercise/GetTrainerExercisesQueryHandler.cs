using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Application.Queries.Exercise;
using TrainingAndDietApp.Application.Responses.Exercise;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.Handlers.Exercise;

public class GetTrainerExercisesQueryHandler : IRequestHandler<GetTrainerExercisesQuery, IEnumerable<ExerciseNameResponse>>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public GetTrainerExercisesQueryHandler(IMapper mapper, IExerciseRepository exerciseRepository, IUserService userService)
    {
        _mapper = mapper;
        _exerciseRepository = exerciseRepository;
        _userService = userService;
    }
    public async Task<IEnumerable<ExerciseNameResponse>> Handle(GetTrainerExercisesQuery request, CancellationToken cancellationToken)
    {
        if(! await _userService.CheckIfUserExists(request.TrainerId, cancellationToken))
            throw new NotFoundException("Trainer not found");

        if (! (await _userService.CheckIfUserIsTrainer(request.TrainerId, cancellationToken) || await _userService.CheckIfUserIsDieticianTrainer(request.TrainerId, cancellationToken)))
            throw new BadRequestException("User is not a trainer");

        var exercises = await _exerciseRepository.GetTrainerExercisesAsync(request.TrainerId, cancellationToken);

        return _mapper.Map<List<ExerciseNameResponse>>(exercises);


    }
}