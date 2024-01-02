using AutoMapper;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Repositories;
using TrainingAndDietApp.Common.DTOs.Exercise;
using TrainingAndDietApp.Common.Exceptions;

namespace TrainingAndDietApp.BLL.Services
{
    public interface IExerciseService
    {
        Task<ExerciseDto> GetExerciseById(int exerciseId);
        Task<List<ExerciseNameDto>> GetAllExercises();
        Task<int> CreateExercise(ExerciseDto exerciseDto);

        Task<List<ExerciseDto>> GetTrainerExercises(int trainerId);


        Task<ExerciseDto> UpdateExercise(ExerciseDto exercise, int exerciseId);
    }
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public ExerciseService(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task<List<ExerciseNameDto>> GetAllExercises()
        {
            var exercises = await _exerciseRepository.GetAllExercisesAsync();

            if (exercises == null)
            {
                throw new NotFoundException("Exercises not found");
            }

            return _mapper.Map<List<ExerciseNameDto>>(exercises);
        }

        public async Task<ExerciseDto> GetExerciseById(int ExerciseId)
        {
            var exercise = await _exerciseRepository.GetExerciseByIdAsync(ExerciseId);

            if (exercise == null)
            {
                throw new NotFoundException("Exercise not found");
            }

            return _mapper.Map<ExerciseDto>(exercise);
        }

        public async Task<int> CreateExercise(ExerciseDto exerciseDTO)
        {
            var exercise = _mapper.Map<Exercise>(exerciseDTO);
            return await _exerciseRepository.CreateExerciseAsync(exercise);
        }

        public async Task<List<ExerciseDto>> GetTrainerExercises(int trainerId)
        {
            var exercises = await _exerciseRepository.GetTrainerExercisesAsync(trainerId);

            if (!exercises.Any())
                throw new NotFoundException("Exercises not found");


            return _mapper.Map<List<ExerciseDto>>(exercises);

        }

        public async Task<ExerciseDto> UpdateExercise(ExerciseDto exerciseDTO, int ExerciseId)
        {
            var exercise = await _exerciseRepository.GetExerciseByIdAsync(ExerciseId);

            if (exercise == null)
            {
                throw new NotFoundException("Exercise not found");
            }

            _mapper.Map(exerciseDTO, exercise);
            await _exerciseRepository.UpdateExerciseAsync(exercise);

            return _mapper.Map<ExerciseDto>(exercise);
        }
    }
}
