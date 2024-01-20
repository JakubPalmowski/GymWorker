using Microsoft.EntityFrameworkCore;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;
using TrainingAndDietApp.Infrastructure.Context;

namespace TrainingAndDietApp.Infrastructure.Repositories
{

    public class ExerciseRepository :  IExerciseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExerciseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Exercise>> GetExercisesFromTrainingPlanAsync(int idTrainingPlan, CancellationToken cancellation)
        {
            var exercises = await _context.Trainee_exercises
                .Where(e => e.IdTrainingPlan == idTrainingPlan)
                .Select(e => e.IdExercise)
                .ToListAsync(cancellationToken: cancellation);

            var exercisesFromTrainingPlan =  await _context.Exercises
                .Where(e => exercises.Contains(e.IdExercise))
                .ToListAsync(cancellationToken: cancellation);

            return exercisesFromTrainingPlan;

        }

        
        public async Task<List<Exercise>> GetTrainerExercisesAsync(int trainerId, CancellationToken cancellation)
        {
            return  await _context.Exercises.Where(e => e.IdTrainer == trainerId).ToListAsync(cancellation);

        }


        public async Task<bool> CheckIfExerciseExists(int exerciseId)
        {
            var exercise = await _context.Exercises
                .Where(exercise => exercise.IdExercise== exerciseId)
                .ToListAsync();

            return exercise.Any();
        }


        public Task<List<Exercise>> GetSystemExercisesAsync(CancellationToken cancellation)
        {
            return _context.Exercises.Where(e => e.IdTrainer == null).ToListAsync(cancellation);
        }

        public async Task<List<Exercise>> GetAdminExercisesAsync(CancellationToken cancellationToken)
        => await _context.Exercises.Where(e => e.IdTrainer == null).ToListAsync(cancellationToken);

    }
}
