using AutoMapper;
using Training_and_diet_backend.DTOs.TrainingPlan;
using Training_and_diet_backend.Models;
using Training_and_diet_backend.Repositories;
using TrainingAndDietApp.BLL.EntityModels;
using TrainingAndDietApp.Common.DTOs.Exercise;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Models;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;

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
        private readonly IUserServiceDeprecated _userServiceDeprecated;
        private readonly IMapper _mapper;

        public TrainingPlanService(ITrainingPlanRepository trainingPlanRepository, IMapper mapper,
            IUserServiceDeprecated userServiceDeprecated)
        {
            _trainingPlanRepository = trainingPlanRepository;
            _mapper = mapper;
            _userServiceDeprecated = userServiceDeprecated;
        }

        public async Task<int> AddTrainingPlan(TrainingPlanEntity trainingPlanEntity)
        {
            if (!await CheckIfUserIsTrainer(trainingPlanEntity.IdTrainer))
                throw new BadRequestException("User is not a trainer");

            var trainingPlan = _mapper.Map<TrainingPlan>(trainingPlanEntity);
            return await _trainingPlanRepository.AddTrainingPlanAsync(trainingPlan, CancellationToken.None);
        }

        public async Task<TrainingPlanEntity> GetTrainingPlanById(int trainingPlanId)
        {
            var plan = await _trainingPlanRepository.GetTrainingPlanByIdAsync(trainingPlanId, CancellationToken.None);

            if (plan == null)
                throw new NotFoundException("Training plan not found");

            return _mapper.Map<TrainingPlanEntity>(plan);
        }

        private async Task<bool> CheckIfUserIsTrainer(int trainingPlanId)
        {
            return await _userServiceDeprecated.UserIsTrainer(trainingPlanId);
        }
    }
}