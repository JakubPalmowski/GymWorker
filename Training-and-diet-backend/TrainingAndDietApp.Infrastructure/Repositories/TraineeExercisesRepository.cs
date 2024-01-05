using Training_and_diet_backend.Models;
using TrainingAndDietApp.DAL.Context;
using TrainingAndDietApp.DAL.Models;
using TrainingAndDietApp.Domain.Abstractions;

namespace Training_and_diet_backend.Repositories
{
    
    public class TraineeExercisesRepository : ITraineeExercisesRepository
    {
        private readonly ApplicationDbContext _context;

        public TraineeExercisesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task <int> AddTraineeExercisesAsync(TraineeExercise traineeExercise)
        {
            _context.Trainee_exercises.Add(traineeExercise);
            await _context.SaveChangesAsync();
            return traineeExercise.IdExercise;
        }
    }
}
