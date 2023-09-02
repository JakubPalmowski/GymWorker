using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.DTOs;
using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Services
{
    public class TrainingPlanService : ITrainingPlanService
    {

        private readonly ApplicationDbContext _context;

        public TrainingPlanService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddTrainingPlan(Training_plan training_Plan)
        {
            _context.Training_plans.Add(training_Plan);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetTrainingPlanByIdDTO>> GetTrainingPlanById (int trainingPlanId)
        {
            return await _context.Training_plans
                .Where(plan => plan.Id_Training_plan == trainingPlanId)
                .Select(plan => new GetTrainingPlanByIdDTO
                {
                    IdTrainingPlan = trainingPlanId,
                    Name = plan.Name,
                    Type = plan.Type,
                    StartDate = plan.Start_date,
                    EndDate = plan.End_date,

                }).ToListAsync();
        }
    }
}
