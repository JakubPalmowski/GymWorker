using AutoMapper;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Repositories;
using TrainingAndDietApp.BLL.EntityModels;
using TrainingAndDietApp.BLL.Models;
using TrainingAndDietApp.Common.DTOs.Exercise;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Repositories;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

namespace TrainingAndDietApp.BLL.Services
{
    public interface IExerciseService
    {
        Task<ExerciseEntity> GetExerciseById(int exerciseId);
        Task<List<ExerciseEntity>> GetAllExercises();
        Task<int> CreateExercise(ExerciseEntity exerciseEntity);

        Task<List<ExerciseEntity>> GetTrainerExercises(int trainerId);

        Task<List<ExerciseEntity>> GetExercisesFromTrainingPlan(int idTrainingPlan);
        Task<int> UpdateExercise(ExerciseEntity exerciseEntity, int exerciseId);
        Task<int> DeleteExercise(int exerciseId);
    }
    public class ExerciseService : IExerciseService
    {
        private readonly IUserServiceDeprecated _userServiceDeprecated;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly ITrainingPlanRepository _trainingPlanRepository;
        private readonly IMapper _mapper;


        public ExerciseService(IExerciseRepository exerciseRepository, IMapper mapper, IUserServiceDeprecated userServiceDeprecated, ITrainingPlanRepository trainingPlanRepository)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
            _userServiceDeprecated = userServiceDeprecated;
            _trainingPlanRepository = trainingPlanRepository;
        }

        public async Task<List<ExerciseEntity>> GetAllExercises()
        {
            var exercises = await _exerciseRepository.GetAllExercisesAsync();

            return _mapper.Map<List<ExerciseEntity>>(exercises);
        }

        public async Task<ExerciseEntity> GetExerciseById(int exerciseId)
        {
            var exercise = await _exerciseRepository.GetExerciseByIdAsync(exerciseId);

            return _mapper.Map<ExerciseEntity>(exercise);
        }

        public async Task<int> CreateExercise(ExerciseEntity exerciseEntity)
        {
            var exercise = _mapper.Map<Exercise>(exerciseEntity);
            if (exerciseEntity.IdTrainer is null)
                return await _exerciseRepository.CreateExerciseAsync(exercise, CancellationToken.None);
            

            if (!await _userServiceDeprecated.UserExists(exerciseEntity.IdTrainer))
                throw new NotFoundException("User does not exist");

            if (!await _userServiceDeprecated.UserIsTrainer(exerciseEntity.IdTrainer))
                throw new BadRequestException("User is not trainer");

            return await _exerciseRepository.CreateExerciseAsync(exercise, CancellationToken.None);

        }

        public async Task<List<ExerciseEntity>> GetTrainerExercises(int trainerId)
        {
            if (!await _userServiceDeprecated.UserIsTrainer(trainerId))
                throw new BadRequestException("User is not trainer");

            var exercises = await _exerciseRepository.GetTrainerExercisesAsync(trainerId);

            return _mapper.Map<List<ExerciseEntity>>(exercises);

        }

        public async Task<List<ExerciseEntity>> GetExercisesFromTrainingPlan(int idTrainingPlan)
        {
            var exercises = await _exerciseRepository.GetExercisesFromTrainingPlanAsync(idTrainingPlan);

            if (!await IsTrainingPlanValid(idTrainingPlan))
                throw new NotFoundException("Training plan does not exist");

            if (!exercises.Any())
                throw new NotFoundException("There were no exercises assigned to the training plan");

            return _mapper.Map<List<ExerciseEntity>>(exercises);

        }

        public async Task<int> UpdateExercise(ExerciseEntity exerciseEntity, int exerciseId)
        {
            if (!await _userServiceDeprecated.UserExists(exerciseEntity.IdTrainer))
                throw new NotFoundException("User does not exist");

            if (!await _userServiceDeprecated.UserIsTrainer(exerciseEntity.IdTrainer))
                throw new BadRequestException("User is not trainer");
            
            var exercise = await _exerciseRepository.GetExerciseByIdAsync(exerciseId);

            _mapper.Map(exerciseEntity, exercise);
            await _exerciseRepository.UpdateExerciseAsync(exercise);

            return exerciseId;
        }
        public async Task<int> DeleteExercise(int exerciseId)
        {

            await _exerciseRepository.DeleteExerciseAsync(exerciseId);

            return exerciseId;
        }
        private async Task<bool> IsTrainingPlanValid(int trainingPlanId)
        {
            return await _trainingPlanRepository.CheckIfTrainingPlanExists(trainingPlanId);
        }
    }
}
