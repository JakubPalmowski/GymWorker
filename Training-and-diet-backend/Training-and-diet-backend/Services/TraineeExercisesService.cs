using Microsoft.AspNetCore.Mvc;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Services
{

    public class TraineeExercisesService : ITraineeExercisesService
    {
        private readonly ApplicationDbContext _context;

        public TraineeExercisesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddTraineeExercises(Trainee_exercise TraineeExercise)
        {



            await _context.Trainee_exercises.AddAsync(TraineeExercise);

            await _context.SaveChangesAsync();
        }
    }
}
