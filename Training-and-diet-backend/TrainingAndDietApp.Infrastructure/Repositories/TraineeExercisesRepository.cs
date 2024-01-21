using Microsoft.EntityFrameworkCore;
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



        public async Task<TraineeExercise?> GetTraineeExerciseWithExerciseByIdAsync(int idTraineeExercise,
            CancellationToken cancellationToken)
        {
            return await _context.Trainee_exercises
                .Where(e => e.IdTraineeExercise == idTraineeExercise)
                .Include(e => e.Exercise)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }


        public async Task<IEnumerable<TraineeExercise>> GetExercisesFromTrainingPlanAsync(int idTrainingPlan, CancellationToken cancellationToken)
        {
            return await _context.Trainee_exercises
                .Where(te => te.IdTrainingPlan == idTrainingPlan)
                .Include(te => te.Exercise)
                .ToListAsync(cancellationToken);
            
        }

        public async Task<TraineeExercise?> GetTraineeExerciseWithTrainingPlanAndTrainerByIdAsync(int idTrainingPlan, CancellationToken cancellationToken)
        {
            return await _context.Trainee_exercises.Where(te => te.IdTrainingPlan == idTrainingPlan)
                .Include(te => te.TrainingPlan)
                .ThenInclude(tp => tp.Trainer)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TraineeExercise?> GetTraineeExerciseWithTrainingPlanAndPupilByIdAsync(int idTrainingPlan, CancellationToken cancellationToken)
        {
            return await _context.Trainee_exercises.Where(te => te.IdTrainingPlan == idTrainingPlan)
                .Include(te => te.TrainingPlan)
                .ThenInclude(tp => tp.Pupil)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
