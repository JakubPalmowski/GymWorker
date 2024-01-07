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
    }
}
