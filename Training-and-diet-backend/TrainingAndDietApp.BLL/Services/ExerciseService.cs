using AutoMapper;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Repositories;
using TrainingAndDietApp.BLL.EntityModels;
using TrainingAndDietApp.BLL.Models;
using TrainingAndDietApp.Common.DTOs.Exercise;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Repositories;

namespace TrainingAndDietApp.BLL.Services
{
    public interface IExerciseService
    {
        Task<ExerciseEntity> GetExerciseById(int exerciseId);
        Task<List<ExerciseEntity>> GetAllExercises();
        Task<int> CreateExercise(ExerciseEntity exerciseEntity);

        Task<List<ExerciseEntity>> GetTrainerExercises(int trainerId);


        Task<int> UpdateExercise(ExerciseEntity exerciseEntity, int exerciseId);
    }
    public class ExerciseService : IExerciseService
    {
        private readonly IUserService _userService;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;


        public ExerciseService(IExerciseRepository exerciseRepository, IMapper mapper, IUserService userService)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
            _userService = userService;
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
                return await _exerciseRepository.CreateExerciseAsync(exercise);
            

            if (!await _userService.UserExists(exerciseEntity.IdTrainer))
                throw new NotFoundException("User does not exist");

            if (!await _userService.UserIsTrainer(exerciseEntity.IdTrainer))
                throw new BadRequestException("User is not trainer");

            return await _exerciseRepository.CreateExerciseAsync(exercise);

        }

        public async Task<List<ExerciseEntity>> GetTrainerExercises(int trainerId)
        {
            if (!await _userService.UserIsTrainer(trainerId))
                throw new BadRequestException("User is not trainer");

            var exercises = await _exerciseRepository.GetTrainerExercisesAsync(trainerId);

            return _mapper.Map<List<ExerciseEntity>>(exercises);

        }

        public async Task<int> UpdateExercise(ExerciseEntity exerciseEntity, int exerciseId)
        {
            if (!await _userService.UserExists(exerciseEntity.IdTrainer))
                throw new NotFoundException("User does not exist");

            if (!await _userService.UserIsTrainer(exerciseEntity.IdTrainer))
                throw new BadRequestException("User is not trainer");
            
            var exercise = await _exerciseRepository.GetExerciseByIdAsync(exerciseId);

            _mapper.Map(exerciseEntity, exercise);
            await _exerciseRepository.UpdateExerciseAsync(exercise);

            return exerciseId;
        }
    }
}
