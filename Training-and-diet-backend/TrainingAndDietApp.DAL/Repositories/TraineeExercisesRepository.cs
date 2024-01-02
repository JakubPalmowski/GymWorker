using Training_and_diet_backend.Models;
using TrainingAndDietApp.DAL.Context;

namespace Training_and_diet_backend.Repositories
{
    public interface ITraineeExercisesRepository
    {
        Task AddTraineeExercisesAsync(TraineeExerciseEntity traineeExerciseEntity);
    }
    public class TraineeExercisesRepository : ITraineeExercisesRepository
    {
        private readonly ApplicationDbContext _context;

        public TraineeExercisesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddTraineeExercisesAsync(TraineeExerciseEntity traineeExerciseEntity)
        {
            await _context.Trainee_exercises.AddAsync(traineeExerciseEntity);

            await _context.SaveChangesAsync();
        }
    }
}
