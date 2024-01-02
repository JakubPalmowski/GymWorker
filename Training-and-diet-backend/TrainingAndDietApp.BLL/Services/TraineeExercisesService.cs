using Training_and_diet_backend.Models;
using TrainingAndDietApp.DAL.Context;

namespace Training_and_diet_backend.Services
{
    public interface ITraineeExercisesService
    {
        Task AddTraineeExercises(TraineeExerciseEntity traineeExerciseEntity);
    }
    public class TraineeExercisesService : ITraineeExercisesService
    {
        private readonly ApplicationDbContext _context;

        public TraineeExercisesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddTraineeExercises(TraineeExerciseEntity traineeExerciseEntity)
        {

            await _context.Trainee_exercises.AddAsync(traineeExerciseEntity);

            await _context.SaveChangesAsync();
        }
    }
}
