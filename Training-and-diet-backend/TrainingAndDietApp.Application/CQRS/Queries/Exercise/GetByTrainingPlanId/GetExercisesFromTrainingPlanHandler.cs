using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.CQRS.Responses.TraineeExercise;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;

namespace TrainingAndDietApp.Application.CQRS.Queries.Exercise.GetByTrainingPlanId;

public class GetExercisesFromTrainingPlanHandler : IRequestHandler<GetExercisesFromTrainingPlanQuery, IEnumerable<TrainerTraineeExerciseResponse>>
{
    private readonly ITraineeExercisesRepository _traineeExercisesRepository;
    private readonly IMapper _mapper;
    public GetExercisesFromTrainingPlanHandler(IMapper mapper, ITraineeExercisesRepository traineeExercisesRepository)
    {
        _mapper = mapper;
        _traineeExercisesRepository = traineeExercisesRepository;
    }



    public async Task<IEnumerable<TrainerTraineeExerciseResponse>> Handle(GetExercisesFromTrainingPlanQuery request, CancellationToken cancellationToken)
    {
        var traineeExercises = await _traineeExercisesRepository.GetExercisesFromTrainingPlanAsync(request.IdTrainingPlan, cancellationToken);
        if (!traineeExercises.Any())
            throw new NotFoundException("Exercises not found");

        return _mapper.Map<List<TrainerTraineeExerciseResponse>>(traineeExercises);

    }
}