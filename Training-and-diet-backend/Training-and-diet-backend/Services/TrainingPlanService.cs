using Humanizer;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
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

        public async Task<List<GetExerciseGeneralInfoDTO>> GetExercisesFromTrainingPlan(int id_training_plan)
        {
            var planExercises = await _context.Trainee_exercises.Where(e=>e.Id_Training_plan == id_training_plan).Select(e=> e.Id_Exercise).ToListAsync();
            return await _context.Exercises.Where(e => planExercises.Contains(e.Id_Exercise)).Select(e => new GetExerciseGeneralInfoDTO
            { 
            Id = e.Id_Exercise,
            Name = e.Name
        })
            .ToListAsync();
        }

}
}
