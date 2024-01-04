using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Context;
using TrainingAndDietApp.DAL.Models;

namespace TrainingAndDietApp.DAL.Repositories
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetAllExercisesAsync();
        Task<Exercise?> GetExerciseByIdAsync(int exerciseId);

        Task<List<Exercise>> GetExercisesFromTrainingPlanAsync(int idTrainingPlan);
        Task<int> CreateExerciseAsync(Exercise exercise);
        Task<int> UpdateExerciseAsync(Exercise exercise);

        Task <List<Exercise>> GetTrainerExercisesAsync(int trainerId);
        Task<bool> CheckIfExerciseExists(int trainingPlanId);

        Task<int> DeleteExerciseAsync(int exerciseId);
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

        public async Task<List<Exercise>> GetExercisesFromTrainingPlanAsync(int idTrainingPlan)
        {
            var exercises = await _context.Trainee_exercises
                .Where(e => e.IdTrainingPlan == idTrainingPlan)
                .Select(e => e.IdExercise)
                .ToListAsync();

            var exercisesFromTrainingPlan =  await _context.Exercises
                .Where(e => exercises.Contains(e.IdExercise))
                .ToListAsync();

            return exercisesFromTrainingPlan;

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

        public async Task<int> DeleteExerciseAsync(int exerciseId)
        {
            var exercise = await _context.Exercises
                .Where(exercise => exercise.IdExercise == exerciseId)
                .FirstOrDefaultAsync();

            if (exercise == null)
                throw new NotFoundException("Exercise not found");

            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
            return exercise.IdExercise;
        }

        public async Task<bool> CheckIfExerciseExists(int exerciseId)
        {
            var exercise = await _context.Exercises
                .Where(exercise => exercise.IdExercise== exerciseId)
                .ToListAsync();

            return exercise.Any();
        }
    }
}
