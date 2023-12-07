using Training_and_diet_backend.Models;

namespace Training_and_diet_backend.Services
{
    public interface ITraineeExercisesService
    {
        Task AddTraineeExercises(Trainee_exercise TraineeExercise);
    }
}
