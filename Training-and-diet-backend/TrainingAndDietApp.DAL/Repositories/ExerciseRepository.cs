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
        Task<int> UpdateExerciseAsync(Exercise exercise);

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
            var exercises =  await _context.Exercises.ToListAsync();
            if (!exercises.Any())
                throw new NotFoundException("Exercises not found");
            return exercises;
        }

        public async Task<Exercise?> GetExerciseByIdAsync(int exerciseId)
        {
            var exercise =  await _context.Exercises
                .Where(e => e.IdExercise == exerciseId)
                .FirstOrDefaultAsync();
            if (exercise == null)
                throw new NotFoundException("Exercise not found");

            return exercise;
        }

        public async Task<int> CreateExerciseAsync(Exercise exercise)
        {

            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
            return exercise.IdExercise;
        }

        public async Task<int> UpdateExerciseAsync(Exercise exercise)
        {
            _context.Exercises.Update(exercise);
            await _context.SaveChangesAsync();
            return exercise.IdExercise;
        }

        public async Task<List<Exercise>> GetTrainerExercisesAsync(int trainerId)
        {
            var exercises =  await _context.Exercises.Where(e => e.IdTrainer == trainerId).ToListAsync();

            if (!exercises.Any())
                throw new NotFoundException("Exercises not found");

            return exercises;
        }


    }
}
