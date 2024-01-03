using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Context;

namespace TrainingAndDietApp.DAL.Repositories
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetAllExercisesAsync();
        Task<Exercise?> GetExerciseByIdAsync(int exerciseId);
        Task<int> CreateExerciseAsync(Exercise exercise);
        Task UpdateExerciseAsync(Exercise exercise);

        Task <List<Exercise>> GetTrainerExercisesAsync(int trainerId);
    }
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExerciseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Exercise>> GetAllExercisesAsync()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise?> GetExerciseByIdAsync(int exerciseId)
        {
            return await _context.Exercises
                .Where(e => e.IdExercise == exerciseId)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateExerciseAsync(Exercise exercise)
        {
            if (!await TrainerExists(exercise.IdTrainer))
                throw new NotFoundException($"Trainer with ID {exercise.IdTrainer} not found");
            
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
            return exercise.IdExercise;
        }

        public async Task UpdateExerciseAsync(Exercise exercise)
        {
            if (!await TrainerExists(exercise.IdTrainer))
            {
                throw new NotFoundException($"Trainer with ID {exercise.IdTrainer} not found");
            }

            _context.Exercises.Update(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Exercise>> GetTrainerExercisesAsync(int trainerId)
        {
            return await _context.Exercises.Where(e => e.IdTrainer == trainerId).ToListAsync();
        }



        private async Task<bool> TrainerExists(int? trainerId)
        {
            return await _context.Users.AnyAsync(t => t.IdUser == trainerId);
        }
    }
}
