using AutoMapper;
using MediatR;
using TrainingAndDietApp.Application.Abstractions;
using TrainingAndDietApp.Application.Exceptions;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.Application.CQRS.Commands.TraineeExercises.CreateTraineeExercise;

public class CreateTraineeExerciseCommandHandler : IRequestHandler<CreateTraineeExerciseCommand, CreateTraineeExerciseResponse>
{
    private readonly IRepository<TraineeExercise> _traineeExerciseRepository;
    private readonly IRepository<Domain.Entities.TrainingPlan> _trainingPlanRepository;
    private readonly IRepository<Domain.Entities.Exercise> _exerciseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateTraineeExerciseCommandHandler(IMapper mapper, IRepository<TraineeExercise> traineeExerciseRepository, IUnitOfWork unitOfWork, IRepository<Domain.Entities.TrainingPlan> trainingPlanRepository, IRepository<Domain.Entities.Exercise> exerciseRepository)
    {
        _mapper = mapper;
        _traineeExerciseRepository = traineeExerciseRepository;
        _unitOfWork = unitOfWork;
        _trainingPlanRepository = trainingPlanRepository;
        _exerciseRepository = exerciseRepository;
    }
    public async Task<CreateTraineeExerciseResponse> Handle(CreateTraineeExerciseCommand request, CancellationToken cancellationToken)
    {
        var traineeExercise = await _trainingPlanRepository.GetByIdAsync(request.IdTrainingPlan, cancellationToken);
        if (traineeExercise == null)
            throw new NotFoundException("Training plan not found");

        var exercise = await _exerciseRepository.GetByIdAsync(request.IdExercise, cancellationToken);
        if (exercise == null)
            throw new NotFoundException("Exercise not found");

        var traineeExercises = _mapper.Map<TraineeExercise>(request);

        await _traineeExerciseRepository.AddAsync(traineeExercises, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        var createdId = traineeExercises.IdExercise;

        return new CreateTraineeExerciseResponse { IdTraineeExercise = createdId };
    }
}