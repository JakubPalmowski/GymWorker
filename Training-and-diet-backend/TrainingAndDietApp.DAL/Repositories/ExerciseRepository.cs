using Microsoft.EntityFrameworkCore;
using Training_and_diet_backend.Models;
using TrainingAndDietApp.Common.Exceptions;
using TrainingAndDietApp.DAL.Context;

namespace Training_and_diet_backend.Repositories
{
    public interface IExerciseRepository
    {
        Task<List<ExerciseEntity>> GetAllExercisesAsync();
        Task<ExerciseEntity?> GetExerciseByIdAsync(int exerciseId);
        Task<int> CreateExerciseAsync(ExerciseEntity exerciseEntity);
        Task UpdateExerciseAsync(ExerciseEntity exerciseEntity);

        Task <List<ExerciseEntity>> GetTrainerExercisesAsync(int trainerId);
    }
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExerciseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExerciseEntity>> GetAllExercisesAsync()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<ExerciseEntity?> GetExerciseByIdAsync(int exerciseId)
        {
            return await _context.Exercises
                .Where(e => e.IdExercise == exerciseId)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateExerciseAsync(ExerciseEntity exerciseEntity)
        {
            if (!await TrainerExists(exerciseEntity.IdTrainer))
                throw new NotFoundException($"Trainer with ID {exerciseEntity.IdTrainer} not found");
            
            _context.Exercises.Add(exerciseEntity);
            await _context.SaveChangesAsync();
            return exerciseEntity.IdExercise;
        }

        public async Task UpdateExerciseAsync(ExerciseEntity exerciseEntity)
        {
            if (!await TrainerExists(exerciseEntity.IdTrainer))
            {
                throw new NotFoundException($"Trainer with ID {exerciseEntity.IdTrainer} not found");
            }

            _context.Exercises.Update(exerciseEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ExerciseEntity>> GetTrainerExercisesAsync(int trainerId)
        {
            return await _context.Exercises.Where(e => e.IdTrainer == trainerId).ToListAsync();
        }



        private async Task<bool> TrainerExists(int? trainerId)
        {
            return await _context.Users.AnyAsync(t => t.IdUser == trainerId);
        }
    }
}
