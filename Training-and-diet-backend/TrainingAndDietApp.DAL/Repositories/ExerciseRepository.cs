using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Context;
using Training_and_diet_backend.Exceptions;
using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Repositories
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetAllExercisesAsync();
        Task<Exercise?> GetExerciseByIdAsync(int exerciseId);
        Task<int> CreateExerciseAsync(Exercise exercise);
        Task UpdateExerciseAsync(Exercise exercise);
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
                .Where(e => e.Id_Exercise == exerciseId)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateExerciseAsync(Exercise exercise)
        {
            if (!await TrainerExists(exercise.Id_Trainer))
            {
                throw new NotFoundException($"Trainer with ID {exercise.Id_Trainer} not found");
            }

            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
            return exercise.Id_Exercise;
        }

        public async Task UpdateExerciseAsync(Exercise exercise)
        {
            if (!await TrainerExists(exercise.Id_Trainer))
            {
                throw new NotFoundException($"Trainer with ID {exercise.Id_Trainer} not found");
            }

            _context.Exercises.Update(exercise);
            await _context.SaveChangesAsync();
        }
        private async Task<bool> TrainerExists(int? trainerId)
        {
            return await _context.Users.AnyAsync(t => t.Id_User == trainerId);
        }
    }
}
