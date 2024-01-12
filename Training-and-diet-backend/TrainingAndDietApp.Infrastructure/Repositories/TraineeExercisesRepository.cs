using Microsoft.EntityFrameworkCore;
using TrainingAndDietApp.DAL.Models;
using TrainingAndDietApp.Domain.Abstractions;
using TrainingAndDietApp.Domain.Entities;
using TrainingAndDietApp.Infrastructure.Context;

namespace TrainingAndDietApp.Infrastructure.Repositories
{
    
    public class TraineeExercisesRepository : ITraineeExercisesRepository
    {
        private readonly ApplicationDbContext _context;

        public TraineeExercisesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task <int> AddTraineeExercisesAsync(TraineeExercise traineeExercise, CancellationToken cancellationToken)
        {
            _context.Trainee_exercises.Add(traineeExercise);
            await _context.SaveChangesAsync(cancellationToken);
            return traineeExercise.IdExercise;
        }

        public Task<bool> CheckIfTraineeExerciseExistsAsync(int idTraineeExercise, CancellationToken cancellationToken)
        {
            return _context.Trainee_exercises.AnyAsync(te => te.IdTraineeExercise == idTraineeExercise, cancellationToken);
        }

        public async Task<TraineeExercise?> GetTraineeExerciseByIdAsync(int idTraineeExercise,
            CancellationToken cancellationToken)
        {
            return await _context.Trainee_exercises
                .Where(e => e.IdTraineeExercise == idTraineeExercise)
                .Include(e => e.Exercise)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        public async Task UpdateTraineeExerciseAsync(TraineeExercise traineeExercise, CancellationToken cancellationToken)
        {
            _context.Trainee_exercises.Update(traineeExercise);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteTraineeExerciseAsync(int idTraineeExercise, CancellationToken cancellationToken)
        {
            var traineeExercise = await GetTraineeExerciseByIdAsync(idTraineeExercise, cancellationToken);

            if (traineeExercise != null) _context.Trainee_exercises.Remove(traineeExercise);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<TraineeExercise>> GetExercisesFromTrainingPlanAsync(int idTrainingPlan, CancellationToken cancellationToken)
        {
            return await _context.Trainee_exercises
                .Where(te => te.IdTrainingPlan == idTrainingPlan)
                .Include(te => te.Exercise)
                .ToListAsync(cancellationToken);
            
        }
    }
}
