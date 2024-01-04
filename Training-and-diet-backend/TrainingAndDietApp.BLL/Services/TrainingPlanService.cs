using AutoMapper;
using Training_and_diet_backend.DTOs.TrainingPlan;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Repositories;
using TrainingAndDietApp.Common.DTOs.Exercise;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Models;

namespace TrainingAndDietApp.BLL.Services
{
    public interface ITrainingPlanService
    {
        Task<int> AddTrainingPlan(TrainingPlanCreateDto training_PlanDTO);

        

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
            return await _trainingPlanRepository.AddTrainingPlanAsync(trainingPlan);
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
