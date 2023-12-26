using Training_and_diet_backend.Context;
using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Repositories
{
    public interface ITraineeExercisesRepository
    {
        Task AddTraineeExercisesAsync(Trainee_exercise traineeExercise);
    }
    public class TraineeExercisesRepository : ITraineeExercisesRepository
    {
        private readonly ApplicationDbContext _context;

        public TraineeExercisesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddTraineeExercisesAsync(Trainee_exercise traineeExercise)
        {
            await _context.Trainee_exercises.AddAsync(traineeExercise);

            await _context.SaveChangesAsync();
        }
    }
}
