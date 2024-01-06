using AutoMapper;
using Training_and_diet_backend.Repositories;
using TrainingAndDietApp.BLL.Models;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Models;
using TrainingAndDietApp.DAL.Repositories;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.BLL.Services
{
    public interface ITraineeExercisesServiceDeprecated
    {
        Task <int> AddTraineeExercises(TraineeExerciseEntity traineeExerciseEntity);
    }
    public class TraineeExercisesServiceDeprecatedDeprecated : ITraineeExercisesServiceDeprecated
    {
        private readonly ITraineeExercisesRepository _traineeExercisesRepository;
        private readonly ITrainingPlanRepository _trainingPlanRepository;
        private readonly IExerciseRepository _exercisesRepository;
        private readonly IMapper _mapper;

        public TraineeExercisesServiceDeprecatedDeprecated(ITraineeExercisesRepository traineeExercisesRepository, IMapper mapper, ITrainingPlanRepository trainingPlanRepository, IExerciseRepository exercisesRepository)
        {
            _traineeExercisesRepository = traineeExercisesRepository;
            _mapper = mapper;
            _trainingPlanRepository = trainingPlanRepository;
            _exercisesRepository = exercisesRepository;
        }
        // pomyslec o sprawdzeniu czy user probuje dodac cwiczenie do swojego planu
        public async Task<int> AddTraineeExercises(TraineeExerciseEntity traineeExerciseEntity)
        {
            
            if (!await IsTrainingPlanValid(traineeExerciseEntity.IdTrainingPlan))
                throw new NotFoundException("Training plan not found");

            if (!await IsExerciseValid(traineeExerciseEntity.IdExercise))
                throw new NotFoundException("Exercise not found");

            var traineeExercises = _mapper.Map<TraineeExercise>(traineeExerciseEntity);

            var traineeExercisesId  = await _traineeExercisesRepository.AddTraineeExercisesAsync(traineeExercises);

            return traineeExercisesId;

        }

        private async Task<bool> IsTrainingPlanValid(int trainingPlanId)
        {
            return await _trainingPlanRepository.CheckIfTrainingPlanExists(trainingPlanId, CancellationToken.None);
        }
        private async Task<bool> IsExerciseValid(int trainingPlanId)
        {
            return await _exercisesRepository.CheckIfExerciseExists(trainingPlanId);
        }

    }
}
