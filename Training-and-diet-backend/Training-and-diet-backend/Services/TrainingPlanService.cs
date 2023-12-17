using AutoMapper;
using Humanizer;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.DTOs;
using Training_and_diet_backend.Exceptions;
using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Services
{
    public interface ITrainingPlanService
    {
        Task<int> AddTrainingPlan(PostTrainingPlanDTO training_PlanDTO);

        Task<List<GetExerciseGeneralInfoDTO>> GetExercisesFromTrainingPlan(int id_training_plan);

        Task<List<GetTrainingPlanByIdDTO>> GetTrainingPlanById(int trainingPlanId);
    }
    public class TrainingPlanService : ITrainingPlanService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TrainingPlanService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        public async Task<int> AddTrainingPlan(PostTrainingPlanDTO training_PlanDTO)
        {
            var trainingPlan = _mapper.Map<Training_plan>(training_PlanDTO);
            trainingPlan.CalculatePlanDuration();
            _context.Training_plans.Add(trainingPlan);
            await _context.SaveChangesAsync();
            return trainingPlan.Id_Training_plan;
        }

        public async Task<List<GetExerciseGeneralInfoDTO>> GetExercisesFromTrainingPlan(int id_training_plan)
        {
            var planExercises = await _context.Trainee_exercises
                .Where(e=>e.Id_Training_plan == id_training_plan)
                .Select(e=> e.Id_Exercise)
                .ToListAsync();


            var exercises =  await _context.Exercises.Where(e => planExercises.Contains(e.Id_Exercise)).ToListAsync();

            if (exercises.Count == 0)
                throw new NotFoundException("There were no exercises assigned to the training plan");
            

            return _mapper.Map<List<GetExerciseGeneralInfoDTO>>(exercises);


        }
        public async Task<List<GetTrainingPlanByIdDTO>> GetTrainingPlanById(int trainingPlanId)
        {


            var plans =  await _context.Training_plans
                .Where(plan => plan.Id_Training_plan == trainingPlanId).ToListAsync();

            if (plans.Count == 0)
                throw new NotFoundException("There were no training plans with given id");

            return _mapper.Map<List<GetTrainingPlanByIdDTO>>(plans);
        }

        
    }
}
