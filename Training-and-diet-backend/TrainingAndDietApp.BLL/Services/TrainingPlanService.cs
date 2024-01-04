using AutoMapper;
using Training_and_diet_backend.DTOs.TrainingPlan;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Repositories;
using TrainingAndDietApp.BLL.EntityModels;
using TrainingAndDietApp.Common.DTOs.Exercise;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Models;

namespace TrainingAndDietApp.BLL.Services
{
    public interface ITrainingPlanService
    {
        Task<int> AddTrainingPlan(TrainingPlanEntity trainingPlanEntity);


        Task<TrainingPlanEntity> GetTrainingPlanById(int trainingPlanId);
    }

    public class TrainingPlanService : ITrainingPlanService
    {
        private readonly ITrainingPlanRepository _trainingPlanRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public TrainingPlanService(ITrainingPlanRepository trainingPlanRepository, IMapper mapper,
            IUserService userService)
        {
            _trainingPlanRepository = trainingPlanRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<int> AddTrainingPlan(TrainingPlanEntity trainingPlanEntity)
        {
            if (!await CheckIfUserIsTrainer(trainingPlanEntity.IdTrainer))
                throw new BadRequestException("User is not a trainer");

            var trainingPlan = _mapper.Map<TrainingPlan>(trainingPlanEntity);
            return await _trainingPlanRepository.AddTrainingPlanAsync(trainingPlan);
        }

        public async Task<TrainingPlanEntity> GetTrainingPlanById(int trainingPlanId)
        {
            var plan = await _trainingPlanRepository.GetTrainingPlanByIdAsync(trainingPlanId);

            if (plan == null)
                throw new NotFoundException("Training plan not found");

            return _mapper.Map<TrainingPlanEntity>(plan);
        }

        private async Task<bool> CheckIfUserIsTrainer(int trainingPlanId)
        {
            return await _userService.UserIsTrainer(trainingPlanId);
        }
    }
}