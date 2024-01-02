using AutoMapper;
using Training_and_diet_backend.DTOs.TrainingPlan;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Repositories;
using TrainingAndDietApp.Common.DTOs.Exercise;
using TrainingAndDietApp.Common.Exceptions;

namespace TrainingAndDietApp.BLL.Services
{
    public interface ITrainingPlanService
    {
        Task<int> AddTrainingPlan(TrainingPlanCreateDto training_PlanDTO);

        Task<List<ExerciseNameDto>> GetExercisesFromTrainingPlan(int id_training_plan);

        Task<List<TrainingPlanDetailsDto>> GetTrainingPlanById(int trainingPlanId);
    }
    public class TrainingPlanService : ITrainingPlanService
    {
        private readonly ITrainingPlanRepository _trainingPlanRepository;
        private readonly IMapper _mapper;

        public TrainingPlanService(ITrainingPlanRepository trainingPlanRepository, IMapper mapper)
        {
            _trainingPlanRepository = trainingPlanRepository;
            _mapper = mapper;
        }

        public async Task<int> AddTrainingPlan(TrainingPlanCreateDto training_PlanDTO)
        {
            var trainingPlan = _mapper.Map<TrainingPlan>(training_PlanDTO);
            trainingPlan.CalculatePlanDuration();
            return await _trainingPlanRepository.AddTrainingPlanAsync(trainingPlan);
        }
        // do zmiany, zwraca 404 bez wiadomosci
        public async Task<List<ExerciseNameDto>> GetExercisesFromTrainingPlan(int id_training_plan)
        {
            var exercises = await _trainingPlanRepository.GetExercisesFromTrainingPlanAsync(id_training_plan);

            if (exercises.Count == 0)
                throw new NotFoundException("There were no exercises assigned to the training plan");

            return _mapper.Map<List<ExerciseNameDto>>(exercises);
        }

        public async Task<List<TrainingPlanDetailsDto>> GetTrainingPlanById(int trainingPlanId)
        {
            var plans = await _trainingPlanRepository.GetTrainingPlanByIdAsync(trainingPlanId);

            if (!plans.Any())
                throw new NotFoundException("There were no training plans with given id");

            return _mapper.Map<List<TrainingPlanDetailsDto>>(plans);
        }
    }
}
